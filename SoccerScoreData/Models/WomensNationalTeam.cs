using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Models
{
    public class WomensNationalTeam : NationalTeam
    {
        public WomensNationalTeam()
        {
            this.TeamGender = Gender.Female;
        }
    }
}
