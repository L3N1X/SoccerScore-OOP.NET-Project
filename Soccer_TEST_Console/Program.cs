using SoccerScoreData.Dal;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer_TEST_Console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IRepoData repo = RepoFactory.GetRepoData();
            try
            {
                //IList<NationalTeam> nationalTeams = await repo.GetNationalTeamsAsync(Gender.Male);
                //foreach (NationalTeam nationalTeam in nationalTeams)
                //{
                //    Console.WriteLine(nationalTeam);
                //    Console.WriteLine(nationalTeam.Details());
                //    Console.WriteLine($"Total players in team: {nationalTeam.AllPlayers.Count}");
                //    Console.WriteLine("");
                //    Console.WriteLine($"\tCaptain: {nationalTeam.AllPlayers.FirstOrDefault(p => p.Captain.Equals(true)).Name}");
                //    Console.WriteLine("");
                //    nationalTeam.AllPlayers.ForEach(p => Console.WriteLine($"\t{p}\n\t{p.GetDetails()}"));
                //    Console.WriteLine("");
                //}

                Language language = (Language)Enum.Parse(typeof(Language), "ENG");
                Console.WriteLine(language);

                //var team = await repo.GetNationalTeam(Gender.Male, "CRO");
                //Console.WriteLine(team);
                //team.AllPlayers.ForEach(player => Console.WriteLine(player));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

            }
            //Irepo repo = RepoFactory.GetRepo();
            //try
            //{
            //    IList<Player> players = await repo.GetPlayers(Gender.Male);
            //    foreach (var player in players)
            //    {
            //        Console.WriteLine(player);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);

            //}
        }
    }
}
