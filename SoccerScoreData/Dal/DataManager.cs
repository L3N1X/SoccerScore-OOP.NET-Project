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
        private readonly Irepo repo;
        public Gender FavouriteGender { get; }
        public NationalTeam FavouriteTeam { get; set; }
        public IList<Match> FavouriteTeamMatches { get; set; }
        private readonly IList<NationalTeam> selectionTeams;

        public DataManager(Gender gender)
        {
            repo = RepoFactory.GetRepo();
            this.FavouriteGender = gender;
        }

        public IList<NationalTeam> SelectionTeams
        {
            get
            {
                if (selectionTeams is null)
                    this.LoadSelectionTeams();
                return new List<NationalTeam>(SelectionTeams);
            }
        }

        public async void LoadFavouriteTeam(NationalTeam selectedTeam)
        {
            this.FavouriteTeam = await repo.GetNationalTeamAsync(FavouriteGender, selectedTeam.FifaCode);
        }

        private void LoadSelectionTeams()
        {
            repo.GetTeamsSelectionAsync(FavouriteGender);
        }
    }
}
