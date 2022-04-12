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

        private bool CheckIfGoal(string eventType)
        {
            IList<string> options = new List<string>(new string[] { "goal", "goal-penalty" });
            return options.Contains(eventType);
        }

        private bool CheckIfYellowCard(string eventType)
            => "yellow-card".Equals(eventType);

        private IDictionary<string, int> GameEventDict(IList<Match> matchesData, Predicate<string> eventCondition)
        {
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
                    if (eventCondition(gameEvent.EventType))
                    {
                        //Contains key is used because of errors in JSON like player name typos eg. HATAN BAHBIR/BAHBRI
                        if (events.ContainsKey(gameEvent.PlayerName.ToUpper()))
                            events[gameEvent.PlayerName.ToUpper()]++;
                    }
                }
                foreach (var gameEvent in match.HomeTeamEvents)
                {
                    if (eventCondition(gameEvent.EventType))
                    {
                        if (events.ContainsKey(gameEvent.PlayerName.ToUpper()))
                            events[gameEvent.PlayerName.ToUpper()]++;
                    }
                }
            }
            
            return events;
        }

        public async Task<NationalTeam> GetNationalTeam(Gender gender, string fifacode)
        {
            fifacode = fifacode.ToUpper();
            string endpoint = gender == Gender.Male ? Endpoints.MensSpecificMatch : Endpoints.WomensSpecificMatch;
            endpoint = $"{endpoint}{fifacode}";

            var matchesData = await GetMatchesDataByFifaCode(endpoint);

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

            var goalDict = GameEventDict(matchesData, CheckIfGoal);
            var cardDict = GameEventDict(matchesData, CheckIfYellowCard);

            foreach (var team in teamsSet)
            {
                team.AllPlayers.ForEach(p => {
                    p.Goals = goalDict[p.Name.ToUpper()];
                    p.YellowCards = cardDict[p.Name.ToUpper()];
                });
            }

            return teamsSet.FirstOrDefault(team => team.FifaCode.Equals(fifacode));
        }

        public async Task<IList<NationalTeam>> GetNationalTeams(Gender gender)
        {
            string endpoint = gender == Gender.Male ? Endpoints.MensNationalTeams : Endpoints.WomensNationalTeams;
            var teamsData = await GetTeamsData(endpoint);

            if (gender == Gender.Male)
                teamsData.ToList().ForEach(team => team.TeamGender = Gender.Male);

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

            var goalDict = GameEventDict(matchesData, CheckIfGoal);
            var cardDict = GameEventDict(matchesData, CheckIfYellowCard);

            foreach (var team in teamsSet)
            {
                team.AllPlayers.ForEach(p => {
                    p.Goals = goalDict[p.Name.ToUpper()];
                    p.YellowCards = cardDict[p.Name.ToUpper()];
                });
            }

            return teamsSet.ToList();    
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

        private Task<IList<Match>> GetMatchesDataByFifaCode(string endpoint)
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
