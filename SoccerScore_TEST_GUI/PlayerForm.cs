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
        public Player Player { get; private set; }
        private string country;
        public PlayerForm(Player player, string country)
        {
            this.Player = player;
            this.country = country;
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.Text = Player.Name;
            this.lblName.Text = Player.Name;
            Tools.CenterControlInParentHorizontally(this.lblName);
            this.lblCaptain.Text = Player.Captain ? "Team captain" : String.Empty;
            Tools.CenterControlInParentHorizontally(this.lblCaptain);
            this.lblCountry.Text = country;
            this.lblGoals.Text = Player.Goals.ToString();
            this.lblYellowCards.Text = Player.YellowCards.ToString();
            this.lblPosition.Text = Player.Position.ToString();
            this.lblShirtNumber.Text = Player.ShirtNumber.ToString();

            //this.pbPlayerIcon.Image = Player.IconPath != null  //Ako ima sliku
            this.pbFavoruite.Image = Player.IsFavourite ? Images.favourite : null;
        }
    }
}
