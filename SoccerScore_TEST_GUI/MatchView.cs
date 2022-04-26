using SoccerScoreData.Dal;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerScore_TEST_GUI
{
    public partial class MatchView : UserControl
    {
        public Match Match { get; private set; }
        private readonly NationalTeam favouriteTeam;
        public MatchView(Match match, NationalTeam favouriteTeam)
        {
            this.Match = match;
            this.favouriteTeam = favouriteTeam;
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.lblHomeFifaCode.Text = Match.HomeTeam.FifaCode;
            this.lblAwayFifaCode.Text = Match.AwayTeam.FifaCode;

            if (this.Match.HomeTeam.FifaCode.Equals(this.favouriteTeam.FifaCode))
            {
                this.lblHomeFifaCode.ForeColor = Color.PaleVioletRed;
            }
            else
            {
                this.lblAwayFifaCode.ForeColor = Color.PaleVioletRed;
            }

            this.lblHomeAwayScore.Text = $"{Match.HomeTeam.MatchGoals} - {Match.AwayTeam.MatchGoals}";
            this.lblDate.Text = Match.Datetime.ToShortDateString();
            this.lblAttendance.Text = Match.Attendance.ToString();
            this.lblLocation.Text = Match.Location.ToString();
            
            if (Match.WinnerCode == Match.HomeTeam.FifaCode)
                this.pbHomeWinner.Image = Images.trophy;
            else
                this.pbAwayWinner.Image = Images.trophy;

            if (Match.HomeTeam.MatchGoals.Equals(Match.AwayTeam.MatchGoals))
            {
                this.pbHomeWinner.Image = null;
                this.pbAwayWinner.Image = null;
            }

            Tools.CenterControlInParentHorizontally(this.lblVisitorsLabel);
            Tools.CenterControlInParentHorizontally(this.lblLocation);
            Tools.CenterControlInParentHorizontally(this.lblAttendance);
            Tools.CenterControlInParentHorizontally(this.lblDate);
            Tools.CenterControlInParentHorizontally(this.lblHomeAwayScore);
        }
    }
}
