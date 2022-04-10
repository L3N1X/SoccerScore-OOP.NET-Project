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
            IList<Player> players;
            try
            {
                players = await repo.GetPlayers(Gender.Male);
                int index = 0;
                players.ToList().ForEach(p => Console.WriteLine($"{++index}|{p}"));
                Console.WriteLine(players.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
