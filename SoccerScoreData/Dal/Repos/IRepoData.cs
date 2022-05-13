using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal
{
    public interface IRepoData
    {
        Task<IList<NationalTeam>> GetNationalTeamsSelectionAsync(Gender gender);
        Task<NationalTeam> GetNationalTeamAsync(Gender gender, string fifacode);
        Task<IList<Match>> GetMatchesAsync(Gender gender, string fifaCode);
    }
}
