using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Models
{
    public class Player
    {
        public NationalTeam NationalTeam { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public int ShirtNumber { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   EqualityComparer<NationalTeam>.Default.Equals(NationalTeam, player.NationalTeam) &&
                   Name == player.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = -700376964;
            hashCode = hashCode * -1521134295 + EqualityComparer<NationalTeam>.Default.GetHashCode(NationalTeam);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
        public override string ToString()
            => $"{Name} - Number: {ShirtNumber} - Postion: {Position.ToString()}";
    }
}
