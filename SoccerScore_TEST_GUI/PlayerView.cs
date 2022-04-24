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
        public delegate void FavoutitePlayerAddedDelegate(object sender, EventArgs args);
        public event FavoutitePlayerAddedDelegate FavoutitePlayerAdded;

        public delegate void FavoruitePlayerRemovedDelegate(object sender, EventArgs args);
        public event FavoruitePlayerRemovedDelegate FavouritePlayerRemoved;

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

        private void ToggleFavoruiteOption_Click(object sender, EventArgs e)
        {
            Player.IsFavourite = !Player.IsFavourite;
            if(Player.IsFavourite)
                FavoutitePlayerAdded?.Invoke(this, new EventArgs());
            else if (!Player.IsFavourite)
                FavouritePlayerRemoved?.Invoke(this, new EventArgs());
            InitializeControls();
        }

        public void InitializeControls()
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

            this.ToggleFavouriteOption.Text = this.Player.IsFavourite ? $"Remove {Player.Name} from favoruites" : $"Add {Player.Name} to favoruites";
        }

        public override bool Equals(object obj)
        {
            return obj is PlayerView view &&
                   EqualityComparer<Player>.Default.Equals(Player, view.Player);
        }

        public override int GetHashCode()
        {
            return 1752105248 + EqualityComparer<Player>.Default.GetHashCode(Player);
        }

        private void PlayerView_Click(object sender, EventArgs e)
        {
            
        }

        private void ViewDetailsOption_Click(object sender, EventArgs e)
        {
            Form playerForm = new PlayerForm(Player, "Some Country");
            playerForm.Show();
        }
    }
}
