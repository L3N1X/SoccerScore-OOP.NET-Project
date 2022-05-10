using Newtonsoft.Json;
using RestSharp;
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
    //Add abstract superclass
    public class FileRepoData : IRepoData
    {
        private string JsonToStringFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();
            return File.ReadAllText(path);
        }
        private bool CheckIfOwnGoal(string eventType)
        {
            return "goal-own".Equals(eventType);
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

        private ISet<NationalTeam> GetFilledTeamsSetWithPlayers(IList<Match> matchesData, Gender gender)
        {
            //TO DO: Remove traversing trough all matches, not necesarry, first one is enough
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
            return teamsSet;
        }

        //Interface implementation
        public async Task<NationalTeam> GetNationalTeamAsync(Gender gender, string fifacode)
        {
            string endpoint = gender == Gender.Male ? EndpointsLocal.MensMatches : EndpointsLocal.WomensMatches;
            //endpoint = $"{endpoint}{fifacode.ToUpper()}";

            var matchesData = await GetMatchesDataByFifaCode(endpoint);

            ISet<NationalTeam> teamsSet = GetFilledTeamsSetWithPlayers(matchesData, gender);

            var goalDict = GameEventDict(matchesData, CheckIfGoal);
            var cardDict = GameEventDict(matchesData, CheckIfYellowCard);

            //
            endpoint = gender == Gender.Male ? EndpointsLocal.MensNationalTeams : EndpointsLocal.WomensNationalTeams;
            var detailedTeams = await GetTeamsData(endpoint);

            IDictionary<string, NationalTeam> detailTeamDict = new Dictionary<string, NationalTeam>();
            foreach (var team in detailedTeams)
            {
                detailTeamDict.Add(team.FifaCode, team);
            }
            //

            foreach (var team in teamsSet)
            {
                team.AllPlayers.ForEach(p => {
                    p.Goals = goalDict[p.Name.ToUpper()];
                    p.YellowCards = cardDict[p.Name.ToUpper()];
                });
            }
            NationalTeam searchedTeam = teamsSet.FirstOrDefault(team => team.FifaCode.Equals(fifacode.ToUpper()));
            // Extract to method
            searchedTeam.Draws = detailTeamDict[searchedTeam.FifaCode].Draws;
            searchedTeam.GamesPlayed = detailTeamDict[(searchedTeam.FifaCode)].GamesPlayed;
            searchedTeam.GoalDifferential = detailTeamDict[searchedTeam.FifaCode].GoalDifferential;
            searchedTeam.GoalsAgainst = detailTeamDict[(searchedTeam.FifaCode)].GoalsAgainst;
            searchedTeam.GoalsFor = detailTeamDict[(searchedTeam.FifaCode)].GoalsFor;
            searchedTeam.Losses = detailTeamDict[(searchedTeam.FifaCode)].Losses;
            searchedTeam.Points = detailTeamDict[(searchedTeam.FifaCode)].Points;
            searchedTeam.Wins = detailTeamDict[(searchedTeam.FifaCode)].Wins;
            //
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
        //Make abstract
        //RAW DATA
        private Task<IList<NationalTeam>> GetTeamsData(string path)
        {
            return Task.Run(() =>
            {
                return JsonConvert.DeserializeObject<IList<NationalTeam>>(JsonToStringFromFile(path));
            }
            );
        }

        private Task<IList<Match>> GetMatchesData(string path)
        {
            return Task.Run(() =>
            {
                return JsonConvert.DeserializeObject<IList<Match>>(JsonToStringFromFile(path));
            });
        }

        private Task<IList<Match>> GetMatchesDataByFifaCode(string path)
        {
            return Task.Run(() =>
            {
                return JsonConvert.DeserializeObject<IList<Match>>(JsonToStringFromFile(path));
            });
        }
    }
}

