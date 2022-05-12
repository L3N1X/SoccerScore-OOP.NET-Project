using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal.Repos
{
    public abstract class AbstractRepoData
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

        public IDictionary<string, int> GameEventDict(IList<Match> matchesData, Predicate<string> eventCondition)
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
        public abstract Task<IList<NationalTeam>> GetTeamsData(string endpoint);

        public abstract Task<IList<Match>> GetMatchesData(string endpoint);

        public abstract Task<IList<Match>> GetMatchesDataByFifaCode(string endpoint);
    }
}
