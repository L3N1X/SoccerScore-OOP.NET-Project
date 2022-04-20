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
            this.lblName.Text = Player.Name;
            this.lblShirtNumber.Text = Player.ShirtNumber.ToString();
            this.pbFavourite.Image = this.Player.IsFavourite ? Images.favourite : null;
            this.pbPLayer.Image = Images.default_player_image;
            this.pbCaptain.Image = this.Player.Captain ? Images.captain : null;
            CenterControlInParent(this.lblShirtNumber);
            CenterControlInParentHorizontally(this.lblName);
        }

        private void CenterControlInParent(Control control)
        {
            control.Left = (control.Parent.Width - control.Width) / 2;
            control.Top = (control.Parent.Height - control.Height) / 2;
        }
        private void CenterControlInParentHorizontally(Control control)
        {
            control.Left = (control.Parent.Width - control.Width) / 2;
        }
    }
}
