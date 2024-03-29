﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Models
{
    public class NationalTeam
    {
        private const char DEL = ';';
        public Gender TeamGender { get; set; }
        public List<Player> StartingEleven { get; set; }
        public List<Player> Substitutes { get; set; }
        public List<Player> AllPlayers
        {
            get
            {
                return this.StartingEleven.Concat(this.Substitutes).ToList();
            }
        }

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
        public int Wins { get; set; }

        [JsonProperty("draws")]
        public int Draws { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("games_played")]
        public int GamesPlayed { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("goals_for")]
        public long GoalsFor { get; set; }

        [JsonProperty("goals_against")]
        public long GoalsAgainst { get; set; }

        [JsonProperty("goal_differential")]
        public long GoalDifferential { get; set; }

        [JsonProperty("goals")]
        public int MatchGoals { get; set; }
        //Only used for matches (BEWARE WHEN TO USE)

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

        //public override string ToString()
        //    => $"{this.FifaCode}|{this.Country} - {(this.TeamGender == Gender.Male ? "Men's" : "Women's")} National Team ";
        public override string ToString()
            => this.FifaCode;

        public string FormatForFileLine()
            => $"{this.TeamGender}{DEL}{this.FifaCode}";
        public static NationalTeam ParseFromFileLine(string line)
        {
            string[] data = line.Split(DEL);
            return new NationalTeam()
            {
                TeamGender = (Gender)Enum.Parse(typeof(Gender), data[0]),
                FifaCode = data[1],
            };
        }
        public string Details() => $"{this.Country} {(this.TeamGender == Gender.Female ? "women's" : "men's")} national team";
        public string Statistics() => $"Points: {this.Points}{Environment.NewLine}Wins: {this.Wins}";
    }
}
