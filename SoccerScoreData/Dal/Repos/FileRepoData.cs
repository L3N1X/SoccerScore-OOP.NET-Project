using Newtonsoft.Json;
using RestSharp;
using SoccerScoreData.Dal.Repos;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal
{
    public class FileRepoData : AbstractRepoData, IRepoData
    {
        private string JsonToStringFromFile(string path)
        {

            if (!File.Exists(path))
                throw new FileNotFoundException();
            return File.ReadAllText(path);
        }
        public override Task<IList<NationalTeam>> GetTeamsData(string path)
        {
            return Task.Run(() =>
            {
                return JsonConvert.DeserializeObject<IList<NationalTeam>>(JsonToStringFromFile(path));
            }
            );
        }
        public override Task<IList<Match>> GetMatchesData(string path)
        {
            return Task.Run(() =>
            {
                return JsonConvert.DeserializeObject<IList<Match>>(JsonToStringFromFile(path));
            });
        }
        public override Task<IList<Match>> GetMatchesDataByFifaCode(string path)
        {
            return Task.Run(() =>
            {
                return JsonConvert.DeserializeObject<IList<Match>>(JsonToStringFromFile(path));
            });
        }

        /*Interface implementation*/
        public async Task<NationalTeam> GetNationalTeamAsync(Gender gender, string fifacode)
        {
            string endpoint = gender == Gender.Male ? EndpointsLocal.MensMatches : EndpointsLocal.WomensMatches;

            var matchesData = await GetMatchesDataByFifaCode(endpoint);

            ISet<NationalTeam> teamsSet = GetFilledTeamsSetWithPlayers(matchesData, gender);

            var goalDict = GameEventDict(matchesData, CheckIfGoal);
            var cardDict = GameEventDict(matchesData, CheckIfYellowCard);

            endpoint = gender == Gender.Male ? EndpointsLocal.MensNationalTeams : EndpointsLocal.WomensNationalTeams;
            var detailedTeams = await GetTeamsData(endpoint);

            IDictionary<string, NationalTeam> detailTeamDict = new Dictionary<string, NationalTeam>();
            foreach (var team in detailedTeams)
            {
                detailTeamDict.Add(team.FifaCode, team);
            }

            foreach (var team in teamsSet)
            {
                team.AllPlayers.ForEach(p => {
                    p.Goals = goalDict[p.Name.ToUpper()];
                    p.YellowCards = cardDict[p.Name.ToUpper()];
                });
            }

            NationalTeam searchedTeam = teamsSet.FirstOrDefault(team => team.FifaCode.Equals(fifacode.ToUpper()));
            
            searchedTeam.Draws = detailTeamDict[searchedTeam.FifaCode].Draws;
            searchedTeam.GamesPlayed = detailTeamDict[(searchedTeam.FifaCode)].GamesPlayed;
            searchedTeam.GoalDifferential = detailTeamDict[searchedTeam.FifaCode].GoalDifferential;
            searchedTeam.GoalsAgainst = detailTeamDict[(searchedTeam.FifaCode)].GoalsAgainst;
            searchedTeam.GoalsFor = detailTeamDict[(searchedTeam.FifaCode)].GoalsFor;
            searchedTeam.Losses = detailTeamDict[(searchedTeam.FifaCode)].Losses;
            searchedTeam.Points = detailTeamDict[(searchedTeam.FifaCode)].Points;
            searchedTeam.Wins = detailTeamDict[(searchedTeam.FifaCode)].Wins;
            
            return searchedTeam;
        }

        async public Task<IList<NationalTeam>> GetNationalTeamsSelection(Gender gender)
        {
            string endpoint = gender == Gender.Male ? EndpointsLocal.MensNationalTeams : EndpointsLocal.WomensNationalTeams;
            var teamsData = await GetTeamsData(endpoint);
            foreach (var team in teamsData)
            {
                team.TeamGender = gender;
            }
            return teamsData;
        }

        public async Task<IList<Match>> GetMatchesAsync(Gender gender, string fifaCode)
        {
            string endpoint = gender == Gender.Male ? $"{EndpointsLocal.MensMatches}" : $"{EndpointsLocal.WomensMatches}";
            var matchesData = await GetMatchesData(endpoint);
            IList<Match> matchesFiltered = new List<Match>();
            foreach (Match match in matchesData)
            {
                if(match.AwayTeam.FifaCode.Equals(fifaCode) || match.HomeTeam.FifaCode.Equals(fifaCode))
                    matchesFiltered.Add(match);
            }
            return matchesFiltered;
        }
    }
}

