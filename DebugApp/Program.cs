using SoccerScoreData.Dal;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //foreach (var match in matches)
            //{
            //    Console.WriteLine($"HOME: {match.HomeTeam.FifaCode} AWAY: {match.AwayTeam.FifaCode}");
            //}
            DataManager dm = new DataManager();
            await dm.InitializeData();
            var fifaCodes = dm.GetOpponentsFifaCodes();
            fifaCodes.ToList().ForEach(Console.WriteLine);
            //await AppTestAsync();
        }

        private static async Task AppTestAsync()
        {
            IRepoData repo = RepoFactory.GetRepoDataCloud();
            NationalTeam nationalTeam = await repo.GetNationalTeamAsync(Gender.Male, "CRO");
            var matches = await repo.GetMatchesAsync(Gender.Male, "CRO");
        }
    }
}
