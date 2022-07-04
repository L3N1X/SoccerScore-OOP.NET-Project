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

            //var teams = await dm.GetSelectionTeams();
            //var newTeam = teams.ToList()[0];
            //dm.ResetFavourtiteTeamSettings();
            //dm.SetFavouriteTeam(newTeam);

            await dm.InitializeDataAsync();

            Console.WriteLine("Favourite team:");
            Console.WriteLine(dm.FavouriteTeam.FifaCode);
            Console.WriteLine("----------------------");
            foreach (var code in dm.GetOpponentsFifaCodes())
            {
                Console.WriteLine(code);
            }
            dm.SaveSettings();
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
