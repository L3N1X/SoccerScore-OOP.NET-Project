using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Models
{
    public class Settings
    {
        //Height="620" Width="998"
        private const int maxPlayers = 3;
        private const char DEL = '|';

        public const int DEFAULT_WINDOW_WIDTH_WPF = 998;
        public const int DEFAULT_WINDOW_HEIGHT_WPF = 620;


        public bool IsFullScreen { get; set; }
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }

        public NationalTeam FavouriteTeam { get; set; }
        public Language Language { get; set; }
        public IList<Player> FavouritePlayers { get; private set; }
        public Settings()
        {
            ClearFavouritePlayers();
            WindowHeight = DEFAULT_WINDOW_HEIGHT_WPF;
            WindowWidth = DEFAULT_WINDOW_WIDTH_WPF;
        }
        public void AddFavouritePlayer(Player newFavouirtePlayer)
        {
            newFavouirtePlayer.IsFavourite = true;
            if (FavouritePlayers.ToList().Contains(newFavouirtePlayer))
                return;
            if (FavouritePlayers.Remove(null))
                FavouritePlayers.Add(newFavouirtePlayer);
        }
        public void RemoveFavoruitePlayer(Player playerToRemove)
        {
            if (FavouritePlayers.Remove(playerToRemove))
            {
                FavouritePlayers.Add(null);
            }
        }
        public void ClearFavouritePlayers()
            => FavouritePlayers = new List<Player>() { null, null, null };
        public bool IsDefault()
            => FavouriteTeam is null;
        public string FormatForFileLine()
            => $"{Language}{DEL}{(FavouriteTeam != null ? FavouriteTeam.FormatForFileLine() : string.Empty)}" +
            $"{DEL}{(FavouritePlayers[0] != null ? FavouritePlayers[0].FormatForFileLine() : string.Empty)}" +
            $"{DEL}{(FavouritePlayers[1] != null ? FavouritePlayers[1].FormatForFileLine() : string.Empty)}" +
            $"{DEL}{(FavouritePlayers[2] != null ? FavouritePlayers[2].FormatForFileLine() : string.Empty)}" +
            $"{DEL}{IsFullScreen}{DEL}{WindowWidth}{DEL}{WindowHeight}";
        public static Settings ParseFromFileLine(string line)
        {
            string[] data = line.Split(DEL);
            return new Settings
            {
                Language = (Language)Enum.Parse(typeof(Language), data[0]),
                FavouriteTeam = data[1] != string.Empty ? NationalTeam.ParseFromFileLine(data[1]) : null,
                FavouritePlayers = new List<Player>()
                {
                    data[2] != string.Empty ? Player.ParseFromFileLine(data[2]) : null,
                    data[3] != string.Empty ? Player.ParseFromFileLine(data[3]): null,
                    data[4] != string.Empty ? Player.ParseFromFileLine(data[4]) : null,
                },
                IsFullScreen = bool.Parse(data[5]),
                WindowWidth = int.Parse(data[6]),
                WindowHeight = int.Parse(data[7]),
            };
        }
    }
}
