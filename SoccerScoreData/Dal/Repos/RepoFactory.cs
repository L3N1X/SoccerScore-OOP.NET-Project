using SoccerScoreData.Dal.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal
{
    public static class RepoFactory
    {
        public static IRepoData GetRepoDataCloud() => new OnlineRepoData();
        public static IRepoData GetRepoDataLocal() => new FileRepoData();
        public static IRepoConfig GetRepoConfig() => new FileRepoConfig();
    }
}
