using SoccerScoreData.Dal;
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
    public partial class DefaultForm : Form
    {
        internal DataManager dataManager = new DataManager();
        public DefaultForm()
        {
            InitializeComponent();
            Tools.CenterControlInParent(this.pbLoading);
        }

        private void DefaultForm_Load(object sender, EventArgs e)
        {
            if (dataManager.HasDefaultSettings())
            {
                Form dialog = new InitializeForm(dataManager);
                dialog.ShowDialog();
            }
            InitializeControls();
        }

        private async void InitializeControls()
        {
            this.btnClearAllAndExit.Enabled = false;
            this.playersContainer.Visible = false;
            this.pbLoading.Visible = true;
            await dataManager.LoadFavouriteTeam();
            foreach (var player in dataManager.FavouriteTeam.AllPlayers)
            {
                PlayerView playerViewControl = new PlayerView(player);
                playerViewControl.FavoutitePlayerAdded += PlayerViewControl_FavoutitePlayerAdded;
                playerViewControl.FavouritePlayerRemoved += PlayerViewControl_FavouritePlayerRemoved;
                this.playersContainer.Controls.Add(playerViewControl);
            }
            foreach (var player in dataManager.GetFavouritePlayers())
            {
                //ADD TO SETTINGS, NOT HERE
                player.IsFavourite = true;
                //
                PlayerView playerView = new PlayerView(player);
                playerView.FavoutitePlayerAdded += PlayerViewControl_FavoutitePlayerAdded;
                playerView.FavouritePlayerRemoved += PlayerViewControl_FavouritePlayerRemoved;

                this.favoruitePLayersContainer.Controls.Add(playerView);
            }
            this.lblTitle.Text = $"{dataManager.FavouriteTeam.Details()}";
            Tools.CenterControlInParentHorizontally(this.lblTitle);
            this.pbLoading.Visible = false;
            this.lblTitle.Visible = true;
            this.playersContainer.Visible = true;
            this.favoruitePLayersContainer.Visible = true;
            this.btnClearAllAndExit.Enabled = true;
            this.label1.Visible = true;
            this.label2.Visible = true;
        }

        private void PlayerViewControl_FavouritePlayerRemoved(object sender, EventArgs args)
        {
            PlayerView playerViewToRemove = ((PlayerView)sender);
            
            int allPlayersUpdateIndex = this.playersContainer.Controls.IndexOf(playerViewToRemove);
            ((PlayerView)this.playersContainer.Controls[allPlayersUpdateIndex]).Player.IsFavourite = false;
            ((PlayerView)this.playersContainer.Controls[allPlayersUpdateIndex]).InitializeControls();

            int deleteIndex = this.favoruitePLayersContainer.Controls.IndexOf(playerViewToRemove);
            this.favoruitePLayersContainer.Controls.RemoveAt(deleteIndex);



            dataManager.RemovePlayerFromFavoruites(playerViewToRemove.Player);
        }

        private void PlayerViewControl_FavoutitePlayerAdded(object sender, EventArgs args)
        {
            PlayerView newFavoruitePlayerView = ((PlayerView)sender);
            //DUMB EXCEPTION
            if (newFavoruitePlayerView.Player.IsFavourite && dataManager.GetFavoruitePLayerCount() == dataManager.MAX_FAVORUITE_PLAYERS)
            {
                newFavoruitePlayerView.Player.IsFavourite = false;
                return;
            }
            if (this.favoruitePLayersContainer.Controls.Contains(newFavoruitePlayerView) || dataManager.GetFavoruitePLayerCount() == dataManager.MAX_FAVORUITE_PLAYERS)
                return;
            PlayerView newFavoruitePlayerViewCopy = new PlayerView(newFavoruitePlayerView.Player);
            
            newFavoruitePlayerViewCopy.FavoutitePlayerAdded += PlayerViewControl_FavoutitePlayerAdded;
            newFavoruitePlayerViewCopy.FavouritePlayerRemoved += PlayerViewControl_FavouritePlayerRemoved;
            
            this.favoruitePLayersContainer.Controls.Add(newFavoruitePlayerViewCopy);
            dataManager.AddFavouritePlayer(newFavoruitePlayerView.Player);
        }

        private void btnClearAllAndExit_Click(object sender, EventArgs e)
        {
            dataManager.ResetSettings();
            Application.Exit();
        }
    }
}
