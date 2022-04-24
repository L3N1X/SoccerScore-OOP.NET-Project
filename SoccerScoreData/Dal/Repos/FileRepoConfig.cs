using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal.Repos
{
    internal class FileRepoConfig : IRepoConfig
    {
        private const string FILES_DIR = "Files/";

        private const string PLAYER_IMAGES_DIR = "Players/";
        private const string PLAYERS_IMAGES_PATH = FILES_DIR + PLAYER_IMAGES_DIR + "/players_images.txt";

        private const string SETTINGS_DIR = "Settings/";
        private const string SETTINGS_PATH = FILES_DIR + SETTINGS_DIR + "settings.txt";

        //TODO: FIX WHEN THERE IS NO PLAYER IMAGE FILE

        public IList<Player> GetPlayersWithSavedImage()
        {
            if (!File.Exists(PLAYERS_IMAGES_PATH))
            {
                Directory.CreateDirectory(PLAYER_IMAGES_DIR);
                File.Create(PLAYERS_IMAGES_PATH);
                return new List<Player>();
            }
            string[] lines = File.ReadAllLines(PLAYERS_IMAGES_PATH);
            List<Player> list = new List<Player>();
            foreach (string line in lines)
            {
                Player player = Player.ParseFromFileLine(line);
                if (player.IconPath == null || !File.Exists(player.IconPath))
                    continue;
                list.Add(player);
            }
            return list;
        }

        public void SavePlayersWithImage(IList<Player> newPlayers)
        {
            IList<Player> allPlayers = GetPlayersWithSavedImage();
            foreach (var player in allPlayers)
            {
                Player overwrittenPlayer = newPlayers.FirstOrDefault(newPlayer => newPlayer.Equals(player));
                if(overwrittenPlayer != null)
                {
                    player.IconPath = overwrittenPlayer.IconPath;
                    newPlayers.Remove(overwrittenPlayer);
                }
            }
            foreach (var player in newPlayers)
            {
                allPlayers.Add(player);
            }
            File.WriteAllLines(PLAYERS_IMAGES_PATH, allPlayers.Select(p => p.FormatForFileLine()));
        }

        public Settings GetSettings()
        {
            if (!File.Exists(SETTINGS_PATH))
            {
                Directory.CreateDirectory(FILES_DIR);
                File.Create(SETTINGS_PATH);
                return new Settings();
            }
            string[] lines = File.ReadAllLines(SETTINGS_PATH);
            return Settings.ParseFromFileLine(lines[0]);
        }


        public void SaveSettings(Settings settings)
        {
            File.WriteAllText(SETTINGS_PATH, settings.FormatForFileLine());
        }
    }
}
