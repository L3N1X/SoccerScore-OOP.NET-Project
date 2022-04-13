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
        public bool IsFavourite { get; set; } = false;
        public int Goals { get; set; }
        public int YellowCards { get; set; }

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
                   Name == player.Name &&
                   Captain == player.Captain &&
                   ShirtNumber == player.ShirtNumber &&
                   Position == player.Position;
        }

        public override int GetHashCode()
        {
            int hashCode = 412083565;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Captain.GetHashCode();
            hashCode = hashCode * -1521134295 + ShirtNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + Position.GetHashCode();
            return hashCode;
        }
        public override string ToString()
            => $"{this.Name} {(this.IsFavourite ? "*" : "")}";
        public string GetDetails()
            => $"Goals: {this.Goals}\tYellow cards: {this.YellowCards}\t|\tPosition: {this.Position}\t({this.ShirtNumber})";
    }
}
