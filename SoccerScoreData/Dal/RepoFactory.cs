using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal
{
    public static class RepoFactory
    {
        public static Irepo GetRepo() => new OnlineRepo();
    }
}
