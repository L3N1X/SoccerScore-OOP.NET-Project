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

            //new part, old returns teamsData
            endpoint = gender == Gender.Male ? Endpoints.MensMatches : Endpoints.WomensMatches;
            var matchesData = await GetMatchesData(endpoint);
            ISet<NationalTeam> teamsSet = new HashSet<NationalTeam>();
            foreach (var match in matchesData)
            {
                match.AwayTeam.TeamGender = gender;
                match.HomeTeam.TeamGender = gender;

                TeamStatistics awayTeamStatistics = match.AwayTeamStatistics;
                TeamStatistics homeTeamStatistics = match.HomeTeamStatistics;

                match.AwayTeam.Substitutes = awayTeamStatistics.Substitutes;
                match.AwayTeam.StartingEleven = awayTeamStatistics.StartingEleven;

                match.HomeTeam.Substitutes = homeTeamStatistics.Substitutes;
                match.HomeTeam.StartingEleven = homeTeamStatistics.StartingEleven;

                teamsSet.Add(match.AwayTeam);
                teamsSet.Add(match.HomeTeam);
            }

            foreach (var team in teamsSet)
            {
                NationalTeam searchedTeam = teamsData.FirstOrDefault(t => t.Equals(team));
                if (searchedTeam != null)
                {
                    searchedTeam.StartingEleven = team.StartingEleven;
                    searchedTeam.Substitutes = team.Substitutes;
                }
            }

            return teamsSet.ToList();    
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

                match.AwayTeam.Substitutes = awayTeamStatistics.Substitutes;
                match.AwayTeam.StartingEleven = awayTeamStatistics.StartingEleven;

                match.HomeTeam.Substitutes = homeTeamStatistics.Substitutes;
                match.HomeTeam.StartingEleven = homeTeamStatistics.StartingEleven;

                match.AwayTeam.AllPlayers.ToList().ForEach(player => players.Add(player));
                match.HomeTeam.AllPlayers.ToList().ForEach(player => players.Add(player));
            }
            return players.ToList();
        }

        public async Task<IList<Player>> GetPlayers(Gender gender, NationalTeam nationalTeam)
        {
            //IList<Player> players = await GetPlayers(gender);
            //return players.Where(player => player.NationalTeam == nationalTeam).ToList();
            throw new NotImplementedException();
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
