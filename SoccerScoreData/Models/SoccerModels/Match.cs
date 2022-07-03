using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SoccerScoreData.Models
{
    public class Match
    {
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }

        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("fifa_id")]
        public string FifaCode { get; set; }

        [JsonProperty("stage_name")]
        public string StageName { get; set; }

        [JsonProperty("home_team_country")]
        public string HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public string AwayTeamCountry { get; set; }

        [JsonProperty("datetime")]
        public DateTime Datetime { get; set; }

        [JsonProperty("winner")]
        public string Winner { get; set; }

        [JsonProperty("winner_code")]
        public string WinnerCode { get; set; }

        [JsonProperty("home_team")]
        public NationalTeam HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public NationalTeam AwayTeam { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatisticsData HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatisticsData AwayTeamStatistics { get; set; }

        [JsonProperty("attendance")]
        public int Attendance { get; set; }

        [JsonProperty("home_team_events")]
        public List<TeamEvent> HomeTeamEvents { get; set; }

        [JsonProperty("away_team_events")]
        public List<TeamEvent> AwayTeamEvents { get; set; }

        public override string ToString()
            => $"{HomeTeam.FifaCode} - {AwayTeam.FifaCode}";
    }
}
