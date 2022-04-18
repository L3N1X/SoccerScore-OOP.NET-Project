using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Models
{
    public class Settings
    {
        private const int maxPlayers = 3;
        private const char DEL = '|';
        public NationalTeam FavouriteTeam { get; set; }
        public Language Language { get; set; }
        public IList<Player> FavouritePlayers { get; private set; }
        public void AddFavouritePlayer(Player newFavouirtePlayer)
        {
            newFavouirtePlayer.IsFavourite = true;
            if (FavouritePlayers.ToList().Contains(newFavouirtePlayer))
                return;
            if (FavouritePlayers.Remove(null))
                FavouritePlayers.Add(newFavouirtePlayer);
        }
        public string FormatForFileLine()
            => $"{Language}{DEL}{(FavouriteTeam != null ? FavouriteTeam.FormatForFileLine() : string.Empty)}" +
            $"{DEL}{(FavouritePlayers[0] != null ? FavouritePlayers[0].FormatForFileLine() : string.Empty)}" +
            $"{DEL}{(FavouritePlayers[1] != null ? FavouritePlayers[1].FormatForFileLine() : string.Empty)}" +
            $"{DEL}{(FavouritePlayers[2] != null ? FavouritePlayers[2].FormatForFileLine() : string.Empty)}";
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
                }
            };
        }
    }
}
