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
    internal class OnlineRepoData : AbstractRepoData
    {
        /*Abstract repo override*/
        public override Task<IList<NationalTeam>> GetTeamsDataFromJson(string enpoint)
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(enpoint);
                var apiResult = apiClient.Execute<NationalTeam>(new RestRequest());
                return JsonConvert.DeserializeObject<IList<NationalTeam>>(apiResult.Content);
            }
            );
        }

        public override Task<IList<Match>> GetMatchesDataFromJson(string endpoint)
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(endpoint);
                var apiResult = apiClient.Execute<Match>(new RestRequest());
                return JsonConvert.DeserializeObject<IList<Match>>(apiResult.Content);
            });
        }

        public override Task<IList<Match>> GetMatchesDataByFifaCodeFromJson(string endpoint)
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(endpoint);
                var apiResult = apiClient.Execute<Match>(new RestRequest());
                return JsonConvert.DeserializeObject<IList<Match>>(apiResult.Content);
            });
        }
        /*Abstract repo override*/

        /*Interface Override*/
        public override async Task<NationalTeam> GetNationalTeamAsync(Gender gender, string fifacode)
        {
            string matchesEndpoint = gender == Gender.Male ? EndpointsCloud.MensSpecificMatch : EndpointsCloud.WomensSpecificMatch;
            matchesEndpoint = $"{matchesEndpoint}{fifacode.ToUpper()}";
            string nationalTeamsEndpoint = gender == Gender.Male ? EndpointsCloud.MensNationalTeams : EndpointsCloud.WomensNationalTeams;
            return await GetSelectedNationalTeam(matchesEndpoint, nationalTeamsEndpoint, gender, fifacode);
        }

        public override async Task<IList<NationalTeam>> GetNationalTeamsSelectionAsync(Gender gender)
        {
            string endpoint = gender == Gender.Male ? EndpointsCloud.MensNationalTeams : EndpointsCloud.WomensNationalTeams;
            var teamsData = await GetTeamsDataFromJson(endpoint);
            foreach (var team in teamsData)
            {
                team.TeamGender = gender;
            }
            return teamsData;
        }

        public override async Task<IList<Match>> GetMatchesAsync(Gender gender, string fifaCode)
        {
            string endpoint = gender == Gender.Male ? $"{EndpointsCloud.MensSpecificMatch}{fifaCode.ToUpper()}" : $"{EndpointsCloud.WomensSpecificMatch}{fifaCode.ToUpper()}";
            var matchesData = await GetMatchesDataFromJson(endpoint);
            IList<Match> matchesFiltered = new List<Match>();
            foreach (Match match in matchesData)
            {
                var goalDict = this.GameEventDict(match, CheckIfGoal);
                var yellowCardDict = this.GameEventDict(match, CheckIfYellowCard);

                foreach (Player player in match.HomeTeamStatistics.StartingEleven)
                {
                    player.Goals = goalDict[player.Name];
                    player.YellowCards = yellowCardDict[player.Name];
                }

                foreach (Player player in match.AwayTeamStatistics.StartingEleven)
                {
                    player.Goals = goalDict[player.Name];
                    player.YellowCards = yellowCardDict[player.Name];
                }

                if (match.AwayTeam.FifaCode.Equals(fifaCode) || match.HomeTeam.FifaCode.Equals(fifaCode))
                    matchesFiltered.Add(match);
            }

            return matchesFiltered;
        }
        /*Interface override*/
    }
}
