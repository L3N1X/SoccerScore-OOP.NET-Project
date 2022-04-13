using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal
{
    internal class FileRepo : Irepo
    {
        //JSON JE JEDAN VELIKI STRING; KORISTI STRINGBUILDER!!!!!
        public Task<IList<Match>> GetMatchesAsync(Gender gender, string fifaCode)
        {
            throw new NotImplementedException();
        }

        public Task<NationalTeam> GetNationalTeamAsync(Gender gender, string fifacode)
        {
            throw new NotImplementedException();
        }

        public Task<IList<NationalTeam>> GetNationalTeamsAsync(Gender gender)
        {
            throw new NotImplementedException();
        }

        public Task<IList<NationalTeam>> GetTeamsSelectionAsync(Gender gender)
        {
            throw new NotImplementedException();
        }
    }
}
