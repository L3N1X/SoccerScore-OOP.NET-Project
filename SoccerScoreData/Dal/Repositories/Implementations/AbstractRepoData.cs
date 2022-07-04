using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal.Repos
{
    public abstract class AbstractRepoData : IRepoData
    {
        public bool CheckIfOwnGoal(string eventType)

            => "goal-own".Equals(eventType);

        public bool CheckIfGoal(string eventType)
        {
            IList<string> options = new List<string>(new string[] { "goal", "goal-penalty" });
            return options.Contains(eventType);
        }

        public bool CheckIfYellowCard(string eventType)
            => "yellow-card".Equals(eventType);

        public async Task<NationalTeam> GetSelectedNationalTeam(string matchesEndpoint, string nationalTeamsEndpoint, Gender gender, string fifacode)
        {
            var matchesData = await GetMatchesDataByFifaCodeFromJson(matchesEndpoint);

            ISet<NationalTeam> teamsSet = GetFilledTeamsSetWithPlayers(matchesData, gender);

            var goalDict = GameEventDict(matchesData, CheckIfGoal);
            var cardDict = GameEventDict(matchesData, CheckIfYellowCard);

            var detailedTeams = await GetTeamsDataFromJson(nationalTeamsEndpoint);

            IDictionary<string, NationalTeam> detailTeamDict = new Dictionary<string, NationalTeam>();
            foreach (var team in detailedTeams)
            {
                detailTeamDict.Add(team.FifaCode, team);
            }

            foreach (var team in teamsSet)
            {
                team.AllPlayers.ForEach(p =>
                {
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

        public IDictionary<string, int> GameEventDict(IList<Match> matchesData, Predicate<string> eventCondition)
        {
            IDictionary<string, int> eventDict = new Dictionary<string, int>();
            ISet<string> keys = new HashSet<string>();
            matchesData.ToList().ForEach(m => { m.AwayTeam.AllPlayers.ForEach(p => keys.Add(p.Name.ToUpper())); });
            matchesData.ToList().ForEach(m => { m.HomeTeam.AllPlayers.ForEach(p => keys.Add(p.Name.ToUpper())); });
            foreach (var key in keys)
            {
                eventDict.Add(key, 0);
            }
            foreach (var match in matchesData)
            {
                foreach (var gameEvent in match.AwayTeamEvents)
                {
                    if (eventCondition(gameEvent.EventType))
                    {
                        if (eventDict.ContainsKey(gameEvent.PlayerName.ToUpper()))
                            eventDict[gameEvent.PlayerName.ToUpper()]++;
                    }
                }
                foreach (var gameEvent in match.HomeTeamEvents)
                {
                    if (eventCondition(gameEvent.EventType))
                    {
                        if (eventDict.ContainsKey(gameEvent.PlayerName.ToUpper()))
                            eventDict[gameEvent.PlayerName.ToUpper()]++;
                    }
                }
            }
            return eventDict;
        }

        public IDictionary<string, int> GameEventDict(Match match, Predicate<string> eventCondition)
        {
            IDictionary<string, int> eventDict = new Dictionary<string, int>();
            ISet<string> keys = new HashSet<string>();
            match.HomeTeamStatistics.StartingEleven.ForEach(p => keys.Add(p.Name.ToUpper()));
            match.AwayTeamStatistics.StartingEleven.ForEach(p => keys.Add(p.Name.ToUpper()));
            foreach (var key in keys)
            {
                eventDict.Add(key, 0);
            }

            foreach (var gameEvent in match.AwayTeamEvents)
            {
                if (eventCondition(gameEvent.EventType))
                {
                    if (eventDict.ContainsKey(gameEvent.PlayerName.ToUpper()))
                        eventDict[gameEvent.PlayerName.ToUpper()]++;
                }
            }
            foreach (var gameEvent in match.HomeTeamEvents)
            {
                if (eventCondition(gameEvent.EventType))
                {
                    if (eventDict.ContainsKey(gameEvent.PlayerName.ToUpper()))
                        eventDict[gameEvent.PlayerName.ToUpper()]++;
                }
            }
            return eventDict;
        }

        public ISet<NationalTeam> GetFilledTeamsSetWithPlayers(IList<Match> matchesData, Gender gender)
        {
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
        public abstract Task<IList<NationalTeam>> GetTeamsDataFromJson(string endpoint);

        public abstract Task<IList<Match>> GetMatchesDataFromJson(string endpoint);

        public abstract Task<IList<Match>> GetMatchesDataByFifaCodeFromJson(string endpoint);

        //Interface
        public abstract Task<IList<NationalTeam>> GetNationalTeamsSelectionAsync(Gender gender);

        public abstract Task<NationalTeam> GetNationalTeamAsync(Gender gender, string fifacode);

        public abstract Task<IList<Match>> GetMatchesAsync(Gender gender, string fifaCode);
        //Interface
    }
}
