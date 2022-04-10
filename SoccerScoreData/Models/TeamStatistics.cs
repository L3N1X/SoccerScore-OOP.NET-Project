using Newtonsoft.Json;
using System.Collections.Generic;

namespace SoccerScoreData.Models
{
    public class TeamStatistics
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("starting_eleven")]
        public List<Player> StartingEleven { get; set; }

        [JsonProperty("substitutes")]
        public List<Player> Substitutes { get; set; }
    }
}