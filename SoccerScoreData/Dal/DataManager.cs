using SoccerScoreData.Dal.Repos;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal
{
    public class DataManager
    {
        private readonly IRepoData repoData;
        private readonly IRepoConfig repoConfig; 

        private Settings settings;
        public Gender FavouriteGender { get; }
        public NationalTeam FavouriteTeam { get; set; }
        public IList<Match> FavouriteTeamMatches { get; set; }
        private IList<NationalTeam> selectionTeams;

        public DataManager(Gender gender)
        {
            repoData = RepoFactory.GetRepoData();
            repoConfig = RepoFactory.GetRepoConfig();
            this.FavouriteGender = gender;
        }

        public IList<NationalTeam> SelectionTeams
        {
            get
            {
                if (selectionTeams is null)
                    this.LoadSelectionTeams();
                return new List<NationalTeam>(selectionTeams);
            }
        }

        public async void LoadFavouriteTeam(NationalTeam selectedTeam)
        {
            this.FavouriteTeam = await repoData.GetNationalTeamAsync(FavouriteGender, selectedTeam.FifaCode);
        }

        private async void LoadSelectionTeams()
        {
            this.selectionTeams = await repoData.GetTeamsSelectionAsync(FavouriteGender);
        }
    }
}
