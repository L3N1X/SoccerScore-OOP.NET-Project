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
        public async Task<IList<Match>> GetMatches(Gender gender, string fifaCode)
        {
            string endpoint = gender == Gender.Male ? Endpoints.MensMatches : Endpoints.WomensMatches;
            var matchesData = await GetMatchesData(endpoint);

            return matchesData;
        }

        public async Task<NationalTeam> GetNationalTeam(Gender gender, string fifacode)
        {
            //deprecated
            fifacode = fifacode.ToUpper();
            string endpoint = gender == Gender.Male ? Endpoints.MensNationalTeams : Endpoints.WomensNationalTeams;
            var teamsData = await GetTeamsData(endpoint);
            if (gender == Gender.Male)
                teamsData.ToList().ForEach(team => team.TeamGender = Gender.Male);
            return teamsData.ToList().FirstOrDefault(team => team.FifaCode.Equals(fifacode));
        }

        public bool CheckIfGoal(string eventType)
        {
            IList<string> options = new List<string>(new string[] { "goal", "goal-penalty"/*, "goal-own"*/ });
            return options.Contains(eventType);
        }

        private IDictionary<string, int> GoalDict(IList<Match> matchesData)
        {
            //Make 2D Dict for yellow cards
            IDictionary<string, int> events = new Dictionary<string, int>();
            ISet<string> keys = new HashSet<string>();
            matchesData.ToList().ForEach(m => { m.AwayTeam.AllPlayers.ForEach(p => keys.Add(p.Name.ToUpper())); });
            matchesData.ToList().ForEach(m => { m.HomeTeam.AllPlayers.ForEach(p => keys.Add(p.Name.ToUpper())); });
            foreach (var key in keys)
            {
                events.Add(key, 0);
            }

            foreach (var match in matchesData)
            {
                foreach (var gameEvent in match.AwayTeamEvents)
                {
                    if (CheckIfGoal(gameEvent.EventType))
                    {
                        events[gameEvent.PlayerName.ToUpper()]++;
                    }
                }
                foreach (var gameEvent in match.HomeTeamEvents)
                {
                    if (CheckIfGoal(gameEvent.EventType))
                    {
                        events[gameEvent.PlayerName.ToUpper()]++;
                    }
                }
            }
            return events;
        }

        //Primary data source
        public async Task<IList<NationalTeam>> GetNationalTeams(Gender gender)
        {
            //TODO: MAKE ENDPOINT FOR FIFACODE, ONLY USE ONLY ONE NATIONAL TEAM, NOT ALL....
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

                TeamStatisticsData awayTeamStatistics = match.AwayTeamStatistics;
                TeamStatisticsData homeTeamStatistics = match.HomeTeamStatistics;

                match.AwayTeam.Substitutes = awayTeamStatistics.Substitutes;
                match.AwayTeam.StartingEleven = awayTeamStatistics.StartingEleven;

                match.HomeTeam.Substitutes = homeTeamStatistics.Substitutes;
                match.HomeTeam.StartingEleven = homeTeamStatistics.StartingEleven;

                teamsSet.Add(match.AwayTeam);
                teamsSet.Add(match.HomeTeam);
            }

            var dict = GoalDict(matchesData);
            foreach (var team in teamsSet)
            {
                team.AllPlayers.ForEach(p => p.Goals = dict[p.Name.ToUpper()]);
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

                TeamStatisticsData awayTeamStatistics = match.AwayTeamStatistics;
                TeamStatisticsData homeTeamStatistics = match.HomeTeamStatistics;

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
