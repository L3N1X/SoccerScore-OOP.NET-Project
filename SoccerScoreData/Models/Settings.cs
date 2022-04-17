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
            //newFavouirtePlayer.IsFavourite = true;
            //foreach (var player in this.FavouritePlayers)
            //{
            //    if (player is null)
            //    {
            //        player = newFavouirtePlayer;

            //    }    
            //}
        }
        public string FormatForFileLine()
            => $"{Language}{DEL}{FavouriteTeam}" +
            $"{DEL}{FavouritePlayers?[0]}" +
            $"{DEL}{FavouritePlayers?[1]}" +
            $"{DEL}{FavouritePlayers?[2]}";
        public static Settings ParseFromFileLine(string line)
        {
            string[] data = line.Split(DEL);
            return new Settings
            {
                Language = (Language)Enum.Parse(typeof(Language), data[0]),
                FavouriteTeam = data[1] != string.Empty ? new NationalTeam { FifaCode = data[1] } : null,
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
