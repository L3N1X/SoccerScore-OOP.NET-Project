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
    public class FileRepoData : AbstractRepoData
    {
        /*File repo specific methods*/
        private string JsonToStringFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();
            return File.ReadAllText(path);
        }
        /*File repo specific methods*/

        /*Abstract repo override*/
        public override Task<IList<NationalTeam>> GetTeamsDataFromJson(string path)
        {
            return Task.Run(() =>
            {
                return JsonConvert.DeserializeObject<IList<NationalTeam>>(JsonToStringFromFile(path));
            }
            );
        }
        public override Task<IList<Match>> GetMatchesDataFromJson(string path)
        {
            return Task.Run(() =>
            {
                return JsonConvert.DeserializeObject<IList<Match>>(JsonToStringFromFile(path));
            });
        }
        public override Task<IList<Match>> GetMatchesDataByFifaCodeFromJson(string path)
        {
            return Task.Run(() =>
            {
                return JsonConvert.DeserializeObject<IList<Match>>(JsonToStringFromFile(path));
            });
        }
        /*Abstract repo override*/

        /*Interface implementation*/
        public override async Task<NationalTeam> GetNationalTeamAsync(Gender gender, string fifacode)
        {
            string matchesEndpoint = gender == Gender.Male ? EndpointsLocal.MensMatches : EndpointsLocal.WomensMatches;
            string nationalTeamsEndpoint = gender == Gender.Male ? EndpointsLocal.MensNationalTeams : EndpointsLocal.WomensNationalTeams;

            return await GetSelectedNationalTeam(matchesEndpoint, nationalTeamsEndpoint, gender, fifacode);
        }

        public override async Task<IList<NationalTeam>> GetNationalTeamsSelectionAsync(Gender gender)
        {
            string endpoint = gender == Gender.Male ? EndpointsLocal.MensNationalTeams : EndpointsLocal.WomensNationalTeams;
            var teamsData = await GetTeamsDataFromJson(endpoint);
            foreach (var team in teamsData)
            {
                team.TeamGender = gender;
            }
            return teamsData;
        }

        public override async Task<IList<Match>> GetMatchesAsync(Gender gender, string fifaCode)
        {
            string endpoint = gender == Gender.Male ? $"{EndpointsLocal.MensMatches}" : $"{EndpointsLocal.WomensMatches}";
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

                if(match.AwayTeam.FifaCode.Equals(fifaCode) || match.HomeTeam.FifaCode.Equals(fifaCode))
                    matchesFiltered.Add(match);
            }
            return matchesFiltered;
        }
        /*Interface implementation*/
    }
}

