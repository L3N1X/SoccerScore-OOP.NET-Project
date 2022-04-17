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
        private const string DIR = "../Files";
        private const string SETTINGS_PATH = DIR + "/settings.txt";
        public Settings GetSettings()
        {
            if (!File.Exists(SETTINGS_PATH))
            {
                Directory.CreateDirectory(DIR);
                File.Create(SETTINGS_PATH);
            }
        }

        public void SaveSettings(Settings settings)
        {
            throw new NotImplementedException();
        }
    }
}
