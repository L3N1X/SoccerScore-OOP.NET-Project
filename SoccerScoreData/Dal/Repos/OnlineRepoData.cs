using Newtonsoft.Json;
using RestSharp;
using SoccerScoreData.Dal.Repos;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal
{
    internal class OnlineRepoData : AbstractRepoData, IRepoData
    {
        public override Task<IList<NationalTeam>> GetTeamsData(string enpoint)
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(enpoint);
                var apiResult = apiClient.Execute<NationalTeam>(new RestRequest());
                return JsonConvert.DeserializeObject<IList<NationalTeam>>(apiResult.Content);
            }
            );
        }

        public override Task<IList<Match>> GetMatchesData(string endpoint)
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(endpoint);
                var apiResult = apiClient.Execute<Match>(new RestRequest());
                return JsonConvert.DeserializeObject<IList<Match>>(apiResult.Content);
            });
        }

        public override Task<IList<Match>> GetMatchesDataByFifaCode(string endpoint)
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(endpoint);
                var apiResult = apiClient.Execute<Match>(new RestRequest());
                return JsonConvert.DeserializeObject<IList<Match>>(apiResult.Content);
            });
        }

        /*Interface implementation*/
        public async Task<NationalTeam> GetNationalTeamAsync(Gender gender, string fifacode)
        {
            //THIS PART ONLY DIFFERES IN ENDPOINT
            string endpoint = gender == Gender.Male ? EndpointsCloud.MensSpecificMatch : EndpointsCloud.WomensSpecificMatch;
            endpoint = $"{endpoint}{fifacode.ToUpper()}";

            var matchesData = await GetMatchesDataByFifaCode(endpoint);

            ISet<NationalTeam> teamsSet = GetFilledTeamsSetWithPlayers(matchesData, gender);

            var goalDict = GameEventDict(matchesData, CheckIfGoal);
            var cardDict = GameEventDict(matchesData, CheckIfYellowCard);

            endpoint = gender == Gender.Male ? EndpointsCloud.MensNationalTeams : EndpointsCloud.WomensNationalTeams;
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
            string endpoint = gender == Gender.Male ? EndpointsCloud.MensNationalTeams : EndpointsCloud.WomensNationalTeams;
            var teamsData = await GetTeamsData(endpoint);
            foreach (var team in teamsData)
            {
                team.TeamGender = gender;
            }
            return teamsData;
        }

        public async Task<IList<Match>> GetMatchesAsync(Gender gender, string fifaCode)
        {
            string endpoint = gender == Gender.Male ? $"{EndpointsCloud.MensSpecificMatch}{fifaCode.ToUpper()}" : $"{EndpointsCloud.WomensSpecificMatch}{fifaCode.ToUpper()}";
            var matchesData = await GetMatchesData(endpoint);
            return matchesData;
        }
    }
}
