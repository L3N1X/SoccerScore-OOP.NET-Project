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
    public partial class PlayerView : UserControl
    {
        public Player Player { get; set; }
        public PlayerView(Player player)
        {
            InitializeComponent();
            this.Player = player;
        }

        private void PlayerView_Load(object sender, EventArgs e)
        {
            InitializeControls();
        }

        private void MakeFavouriteOption_Click(object sender, EventArgs e)
        {
            Player.IsFavourite = true;
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.lblName.Text = Player.Name;
            this.lblShirtNumber.Text = Player.ShirtNumber.ToString();
            this.lblPositon.Text = Player.Position.ToString();

            this.pbFavourite.Image = this.Player.IsFavourite ? Images.favourite : null;
            this.pbCaptain.Image = this.Player.Captain ? Images.captain : null;
            this.pbPLayer.Image = Images.default_player_image;

            Tools.CenterControlInParent(this.lblShirtNumber);
            Tools.CenterControlInParentHorizontally(this.lblName);
            Tools.CenterControlInParentHorizontally(this.lblPositon);
        }
    }
}
