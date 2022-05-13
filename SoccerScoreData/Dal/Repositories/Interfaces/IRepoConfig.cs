using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal.Repos
{
    public interface IRepoConfig
    {
        void SaveSettings(Settings settings);
        Settings GetSettings();
        IList<Player> GetPlayersWithSavedImage();
        void SavePlayersWithImage(IList<Player> player);
    }
}
