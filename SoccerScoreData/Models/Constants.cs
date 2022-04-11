using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Models
{
    public enum Gender
    {
        Female,
        Male
    }
    public enum Position
    {
        Goalie,
        Defender,
        Forward,
        Midfield
    }

    public static class EventTypes
    {
        public static readonly string goal = "goal";
        public static readonly string substitution_in = "substitution-in";
        public static readonly string substitution_out = "subsitution-out";
        public static readonly string yellowCard = "yellow-card";
    }

}
