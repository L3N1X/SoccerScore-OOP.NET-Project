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
            DataManager dataManager = new DataManager();
            dataManager.DefaultSettingsFound += DataManager_DefaultSettingsFound;
            dataManager.Initialize();
            try
            {
                //var team = await dataManager.GetFavouriteTeam();
                await dataManager.LoadFavouriteTeam();
                var team = dataManager.FavouriteTeam;
                team.AllPlayers.ForEach(Console.WriteLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

            }
        }

        private static void DataManager_DefaultSettingsFound(object sender, EventArgs args)
        {
            Console.WriteLine("DEFAULT!");
            ((DataManager)sender).SetGender(Gender.Female);
        }
    }
}
