using SoccerScoreData.Dal.Repos;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public int WindowWidth { get => settings.WindowWidth; }
        public int WindowHeight { get => settings.WindowHeight; }
        public bool IsFullScreen { get => settings.IsFullScreen; }

        public DataManager()
        {
            try
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
                    Initialize();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception)
            {
                throw new Exception("Fatal application error");
            }
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
            if (!HasDefaultSettings())
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
        }

        public void SetGender(Gender gender)
            => this.SelectedGender = gender;

        public void SetFavouriteTeam(NationalTeam favouriteTeam)
            => this.settings.FavouriteTeam = favouriteTeam;

        public void SetLanguage(Language language)
            => this.settings.Language = language;

        public void SetWindowPropertiesWPF(int width, int height, bool isFullScreen)
        {
            this.settings.WindowWidth = width;
            this.settings.WindowHeight = height;
            this.settings.IsFullScreen = isFullScreen;
        }

        public Task<IList<NationalTeam>> GetSelectionTeams()
            => repoData.GetNationalTeamsSelectionAsync(this.SelectedGender);


        public void AddFavouritePlayer(Player player)
        {
            this.settings.AddFavouritePlayer(player);
            SaveSettings();
        }

        public async Task InitializeDataAsync()
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

        //public async void InitializeData()
        //{
        //    NationalTeam fullTeam = await repoData.GetNationalTeamAsync(settings.FavouriteTeam.TeamGender, settings.FavouriteTeam.FifaCode);
        //    this.FavouriteTeamMatches = await repoData.GetMatchesAsync(settings.FavouriteTeam.TeamGender, settings.FavouriteTeam.FifaCode);

        //    IList<Player> playersWithSavedImages = repoConfig.GetPlayersWithSavedImage();

        //    this.FavouriteTeam = fullTeam;

        //    //Binds favourite players from settings
        //    settings.FavouritePlayers.ToList().ForEach(player =>
        //    {
        //        if (player != null)
        //        {
        //            Player realPlayer = this.FavouriteTeam.AllPlayers.Find(p => p.Equals(player));
        //            realPlayer.IsFavourite = true;
        //        }
        //    });
        //    playersWithSavedImages.ToList().ForEach(player =>
        //    {
        //        Player realPlayer = this.FavouriteTeam.AllPlayers.Find(p => p.Equals(player));
        //        if (realPlayer != null)
        //            realPlayer.IconPath = player.IconPath;
        //    });
        //}

        public IList<string> GetOpponentsFifaCodes()
        {
            IEnumerable<string> fifaCodes = this.FavouriteTeamMatches
                .Select(match => match.HomeTeam.FifaCode.Equals(FavouriteTeam.FifaCode) ? match.AwayTeam.FifaCode : match.HomeTeam.FifaCode);
            return fifaCodes.ToList();
        }

        public Match GetMatchByOpponentFifaCode(string fifacode)
        {
            var selectedMatch = FavouriteTeamMatches.Where(match =>
            match.AwayTeam.FifaCode.Equals(fifacode) ||
            match.HomeTeam.FifaCode.Equals(fifacode)).ToList()[0];

            IList<Player> playersWithSavedImages = repoConfig.GetPlayersWithSavedImage();

            foreach (var playerWithImage in playersWithSavedImages)
            {
                var homePlayer = selectedMatch.HomeTeamStatistics.StartingEleven.ToList().Find(p => p.Equals(playerWithImage));
                var awayPlayer = selectedMatch.AwayTeamStatistics.StartingEleven.ToList().Find(p => p.Equals(playerWithImage));
                if (homePlayer != null)
                    homePlayer.IconPath = playerWithImage.IconPath;
                if (awayPlayer != null)
                    awayPlayer.IconPath = playerWithImage.IconPath;
            }
            return selectedMatch;
        }

        public void SaveSettings()
            => repoConfig.SaveSettings(settings);
        public void SavePlayersWithImage(IList<Player> playersWithImage)
            => repoConfig.SavePlayersWithImage(playersWithImage);
    }
}
