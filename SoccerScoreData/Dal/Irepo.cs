using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal
{
    public interface Irepo
    {
        Task<IList<NationalTeam>> GetNationalTeams(Gender gender);
        Task<NationalTeam> GetNationalTeam(Gender gender, string fifacode);
        Task<IList<Match>> GetMatches(Gender gender, string fifaCode);
    }
}
