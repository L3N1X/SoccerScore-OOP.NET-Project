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
    public partial class PlayerForm : Form
    {
        public readonly Player player;
        public readonly NationalTeam nationalTeam;
        public PlayerForm(Player player, NationalTeam nationalTeam)
        {
            this.player = player;
            this.nationalTeam = nationalTeam;
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.Text = player.Name;
            this.lblName.Text = player.Name;
            Tools.CenterControlInParentHorizontally(this.lblName);
            this.lblCaptain.Text = player.Captain ? "Team captain" : string.Empty;
            Tools.CenterControlInParentHorizontally(this.lblCaptain);
            this.lblCountry.Text = nationalTeam.Country;
            this.lblGender.Text = nationalTeam.TeamGender.ToString();
            this.lblGoals.Text = player.Goals.ToString();
            this.lblYellowCards.Text = player.YellowCards.ToString();
            this.lblPosition.Text = player.Position.ToString();
            this.lblShirtNumber.Text = player.ShirtNumber.ToString();

            this.pbPlayerIcon.Image = player.IconPath != null ? Image.FromFile(player.IconPath) : Images.default_player_image;
            this.pbFavoruite.Image = player.IsFavourite ? Images.favourite : null;
        }
    }
}
