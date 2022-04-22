using Newtonsoft.Json;

namespace SoccerScoreData.Models
{
    public class TeamEvent
    {
        [JsonProperty("type_of_event")]
        public string EventType { get; set; }

        [JsonProperty("player")]
        public string PlayerName { get; set; }
    }
} 