using SoccerScoreData.Dal.Repos;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal
{
    public class DataManager
    {
        private readonly IRepoData repoData;
        private readonly IRepoConfig repoConfig;
        public DataSource DataSource { get; private set; }
        public int MAX_FAVORUITE_PLAYERS { get; } = 3;

        private Settings settings;
        public Gender SelectedGender { get; private set; }
        public NationalTeam FavouriteTeam { get; private set; }
        public IList<Match> FavouriteTeamMatches { get; private set; }

        public DataManager()
        {
            if (Utils.NetworkTools.CheckForInternetConnection())
            {
                try
                {
                    repoData = RepoFactory.GetRepoDataCloud();
                    this.DataSource = DataSource.Cloud;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    repoData = RepoFactory.GetRepoDataLocal();
                    this.DataSource = DataSource.Local;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            try
            {
                repoConfig = RepoFactory.GetRepoConfig();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Initialize();
        }

        public bool HasDefaultSettings()
            => settings.IsDefault();

        public bool HasMaxAmountOfFavoruitePlayers()
            => GetFavoruitePLayerCount() == this.MAX_FAVORUITE_PLAYERS;

        public void RemovePlayerFromFavoruites(Player player)
            => settings.RemoveFavoruitePlayer(player);

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
            => settings.FavouritePlayers.Count(player => player != null);

        public Language GetLanguage()
            => settings.Language;

        public void ResetFavourtiteTeamSettings()
        {
            this.settings.ClearFavouritePlayers();
            this.settings.FavouriteTeam = null;
            //SaveSettings();
        }

        //For when default settings are detected
        public void SetGender(Gender gender)
        {
            this.SelectedGender = gender;
        }

        public void SetFavouriteTeam(NationalTeam favouriteTeam)
        {
            this.settings.FavouriteTeam = favouriteTeam;
            //SaveSettings();
        }

        public void SetLanguage(Language language)
        {
            this.settings.Language = language;
            //SaveSettings();
        }

        public Task<IList<NationalTeam>> GetSelectionTeams()
            => repoData.GetNationalTeamsSelectionAsync(this.SelectedGender);


        public void AddFavouritePlayer(Player player)
        {
            this.settings.AddFavouritePlayer(player);
            SaveSettings();
        }

        public async Task InitializeData()
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
            => repoConfig.SaveSettings(settings);
        public void SavePlayersWithImage(IList<Player> playersWithImage)
        {
            //SaveSettings();
            repoConfig.SavePlayersWithImage(playersWithImage);
        }
    }
}
