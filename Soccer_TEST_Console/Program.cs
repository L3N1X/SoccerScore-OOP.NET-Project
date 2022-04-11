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
            Irepo repo = RepoFactory.GetRepo();
            try
            {
                IList<NationalTeam> nationalTeams = await repo.GetNationalTeams(Gender.Male);
                foreach (NationalTeam nationalTeam in nationalTeams)
                {
                    Console.WriteLine(nationalTeam);
                    Console.WriteLine($"Total players in team: {nationalTeam.AllPlayers.Count}");
                    Console.WriteLine("");
                    nationalTeam.AllPlayers.ForEach(p => Console.WriteLine($"\t{p}"));
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

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
