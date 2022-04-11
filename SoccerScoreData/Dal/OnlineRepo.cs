using Newtonsoft.Json;
using RestSharp;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal
{
    public class OnlineRepo : Irepo
    {
        public async Task<NationalTeam> GetNationalTeam(Gender gender, string fifacode)
        {
            fifacode = fifacode.ToUpper();
            string endpoint = gender == Gender.Male ? Endpoints.MensNationalTeams : Endpoints.WomensNationalTeams;
            var teamsData = await GetTeamsData(endpoint);
            if (gender == Gender.Male)
                teamsData.ToList().ForEach(team => team.TeamGender = Gender.Male);
            return teamsData.ToList().FirstOrDefault(team => team.FifaCode.Equals(fifacode));
        }

        public async Task<IList<NationalTeam>> GetNationalTeams(Gender gender)
        {
            string endpoint = gender == Gender.Male ? Endpoints.MensNationalTeams : Endpoints.WomensNationalTeams;
            var teamsData = await GetTeamsData(endpoint);
            if (gender == Gender.Male)
                teamsData.ToList().ForEach(team => team.TeamGender = Gender.Male);
            return teamsData;    
        }

        public async Task<IList<Player>> GetPlayers(Gender gender)
        {
            string endpoint = gender == Gender.Male ? Endpoints.MensMatches : Endpoints.WomensMatches;
            var matchesData = await GetMatchesData(endpoint);
            ISet<Player> players = new HashSet<Player>();
            foreach (var match in matchesData)
            {
                match.AwayTeam.TeamGender = gender;
                match.HomeTeam.TeamGender = gender;

                TeamStatistics awayTeamStatistics = match.AwayTeamStatistics;
                TeamStatistics homeTeamStatistics = match.HomeTeamStatistics;

                awayTeamStatistics.Substitutes.ForEach(player => { player.NationalTeam = match.AwayTeam; players.Add(player); });
                awayTeamStatistics.StartingEleven.ForEach(player => { player.NationalTeam = match.AwayTeam; players.Add(player); });

                homeTeamStatistics.Substitutes.ForEach(player => { player.NationalTeam = match.HomeTeam; players.Add(player); });
                homeTeamStatistics.StartingEleven.ForEach(player => { player.NationalTeam = match.HomeTeam; players.Add(player); });
            }
            return players.ToList();
        }

        public async Task<IList<Player>> GetPlayers(Gender gender, NationalTeam nationalTeam)
        {
            IList<Player> players = await GetPlayers(gender);
            return players.Where(player => player.NationalTeam == nationalTeam).ToList();
        }

        private Task<IList<Match>> GetMatchesData(string endpoint)
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(endpoint);
                var apiResult = apiClient.Execute<Match>(new RestRequest());
                return JsonConvert.DeserializeObject<IList<Match>>(apiResult.Content);
            });
        }

        private Task<IList<NationalTeam>> GetTeamsData(string enpoint)
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(enpoint);
                var apiResult = apiClient.Execute<NationalTeam>(new RestRequest());
                return JsonConvert.DeserializeObject<IList<NationalTeam>>(apiResult.Content);
            });
        }

    }
}
