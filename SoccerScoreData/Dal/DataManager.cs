using SoccerScoreData.Dal.Repos;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal
{
    public class DataManager
    {
        private readonly IRepoData repoData;
        private readonly IRepoConfig repoConfig;

        public int MAX_FAVORUITE_PLAYERS { get; } = 3;

        private Settings settings;
        public Gender SelectedGender { get; private set; }
        public NationalTeam FavouriteTeam { get; private set; }
        public IList<Match> FavouriteTeamMatches { get; private set; }

        public DataManager()
        {
            if (Utils.NetworkTools.CheckForInternetConnection())
            {
                repoData = RepoFactory.GetRepoData(); 
            }
            else
            {
                //Initialize file repo, add proper exceptions;
                throw new Exception("No internet connection");
            }
            repoConfig = RepoFactory.GetRepoConfig();
            Initialize();
        }

        public bool HasDefaultSettings()
        {
            return settings.IsDefault();
        }

        public bool HasMaxAmountOfFavoruitePlayers()
        {
            return GetFavoruitePLayerCount() == this.MAX_FAVORUITE_PLAYERS;
        }

        public void RemovePlayerFromFavoruites(Player player)
        {
            settings.RemoveFavoruitePlayer(player);
            SaveSettings();
        }

        public void Initialize()
        {
            settings = repoConfig.GetSettings();
            if(!HasDefaultSettings())
            {
                this.SelectedGender = settings.FavouriteTeam.TeamGender;
                this.FavouriteTeam = settings.FavouriteTeam;
            }
        }

        public int GetFavoruitePLayerCount()
        {
            return settings.FavouritePlayers.Count(player => player != null);
        }

        public void ResetSettingsAndSave()
        {
            this.settings = new Settings();
            SaveSettings();
        }

        //For when default settings are detected
        public void SetGender(Gender gender)
        {
            this.SelectedGender = gender;
        }

        public void SetFavouriteTeam(NationalTeam favouriteTeam)
        {
            this.settings.FavouriteTeam = favouriteTeam;
            SaveSettings();
        }

        public Task<IList<NationalTeam>> GetSelectionTeams()
        {
            return repoData.GetNationalTeamsSelection(this.SelectedGender);
        }

        public void AddFavouritePlayer(Player player)
        {
            this.settings.AddFavouritePlayer(player);
            SaveSettings();
        }

        public async Task InitializeFavoruriteTeam()
        {
            NationalTeam fullTeam = await repoData.GetNationalTeamAsync(settings.FavouriteTeam.TeamGender, settings.FavouriteTeam.FifaCode);
            this.FavouriteTeamMatches = await repoData.GetMatchesAsync(settings.FavouriteTeam.TeamGender, settings.FavouriteTeam.FifaCode);

            IList<Player> playersWithSavedImages = repoConfig.GetPlayersWithSavedImage();

            this.FavouriteTeam = fullTeam;

            //Binds favourite players from settings
            settings.FavouritePlayers.ToList().ForEach(player =>
            {
                if (player != null)
                {
                    Player realPlayer = this.FavouriteTeam.AllPlayers.Find(p => p.Equals(player));
                    realPlayer.IsFavourite = true;
                }
            });
            playersWithSavedImages.ToList().ForEach(player =>
            {
                Player realPlayer = this.FavouriteTeam.AllPlayers.Find(p => p.Equals(player));
                if (realPlayer != null)
                    realPlayer.IconPath = player.IconPath;
            });
        }
        public void SaveSettings()
        {
            repoConfig.SaveSettings(settings);
        }
        public void SaveSettingsOnClose(IList<Player> newPlayers)
        {
            SaveSettings();
            repoConfig.SavePlayersWithImage(newPlayers);
        }
    }
}
