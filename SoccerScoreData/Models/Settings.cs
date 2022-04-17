using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Models
{
    public class Settings
    {
        private const char DEL = '|';
        public NationalTeam FavouriteTeam { get; set; }
        public Language Language { get; set; }
        public IList<Player> FavouritePlayers { get; set; }
        public string FormatForFileLine()
            => $"{FavouriteTeam}|{Language}" +
            $"|{(FavouritePlayers.Count > 0 ? FavouritePlayers[0] : null)}" +
            $"|{(FavouritePlayers.Count > 1 ? FavouritePlayers[1] : null)}" +
            $"|{(FavouritePlayers.Count > 2 ? FavouritePlayers[2] : null)}";
        public static Settings ParseFromFileLine(string line)
        {
            string[] data = line.Split('|');
            return new Settings
            {
                FavouriteTeam = new NationalTeam { FifaCode = data[0] },
                Language = (Language)Enum.Parse(typeof(Language), data[1]),
                FavouritePlayers = new List<Player>()
                {
                    new Player{ Name = data[2] != null ? data[2] : null, IsFavourite = true },
                    new Player{ Name = data[3] != null ? data[3] : null, IsFavourite = true },
                    new Player{ Name = data[4] != null ? data[4] : null, IsFavourite = true },
                }
            };
        }
    }
}
