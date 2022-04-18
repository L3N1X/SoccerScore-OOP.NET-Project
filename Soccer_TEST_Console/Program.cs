using SoccerScoreData.Dal;
using SoccerScoreData.Dal.Repos;
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
            IRepoConfig repoconf = RepoFactory.GetRepoConfig();
            try
            {
                NationalTeam team = await repo.GetNationalTeamAsync(Gender.Male, "cRo");
                team.AllPlayers.ForEach(Console.WriteLine);
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
