using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Models
{
    public class NationalTeam
    {
        public Gender TeamGender { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("fifa_code")] //Fifa code and code are the same value
        public string FifaCode { set; get; }

        [JsonProperty("code")] // same value as FifaCode, Code is from match json, fifacode is from national teams json
        public string Code { set { FifaCode = value; } }

        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }

        [JsonProperty("wins")]
        public long Wins { get; set; }

        [JsonProperty("draws")]
        public long Draws { get; set; }

        [JsonProperty("losses")]
        public long Losses { get; set; }

        [JsonProperty("games_played")]
        public long GamesPlayed { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("goals_for")]
        public long GoalsFor { get; set; }

        [JsonProperty("goals_against")]
        public long GoalsAgainst { get; set; }

        [JsonProperty("goal_differential")]
        public long GoalDifferential { get; set; }

        public override bool Equals(object obj)
        {
            return obj is NationalTeam team &&
                   TeamGender == team.TeamGender &&
                   FifaCode == team.FifaCode;
        }

        public override int GetHashCode()
        {
            int hashCode = -872732333;
            hashCode = hashCode * -1521134295 + TeamGender.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FifaCode);
            return hashCode;
        }

        public override string ToString()
            => $"{this.FifaCode}|{this.Country} - {(this.TeamGender == Gender.Male ? "Men's" : "Women's")} National Team ";
    }
}
