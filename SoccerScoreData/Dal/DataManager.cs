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
        public delegate void DefaultSettingsFoundDelegate(object sender, EventArgs args);
        public event DefaultSettingsFoundDelegate DefaultSettingsFound;

        private readonly IRepoData repoData;
        private readonly IRepoConfig repoConfig; 

        private Settings settings;
        public Gender SelectedGender { get; private set; }
        public NationalTeam FavouriteTeam { get; set; }
        public IList<Match> FavouriteTeamMatches { get; set; }
        public DataManager()
        {
            repoData = RepoFactory.GetRepoData();
            repoConfig = RepoFactory.GetRepoConfig();
        }

        public void Initialize()
        {
            settings = repoConfig.GetSettings();
            if (settings.IsDefault()) 
                DefaultSettingsFound?.Invoke(this, new EventArgs());
            else
            {
                this.SelectedGender = settings.FavouriteTeam.TeamGender;
                this.FavouriteTeam = settings.FavouriteTeam;
            }
        }
        //For getting selection teams
        public void SetGender(Gender gender)
        {
            this.SelectedGender = gender;
        }

        public void SetFavouriteTeam(NationalTeam favouriteTeam)
        {
            this.settings.FavouriteTeam = favouriteTeam;
            repoConfig.SaveSettings(settings);
        }

        public Task<IList<NationalTeam>> GetSelectionTeams()
        {
            return repoData.GetTeamsSelectionAsync(this.SelectedGender);
        }

        public Task<NationalTeam> GetFavouriteTeam()
        {
            return repoData.GetNationalTeamAsync(settings.FavouriteTeam.TeamGender, settings.FavouriteTeam.FifaCode);
        }

    }
}
