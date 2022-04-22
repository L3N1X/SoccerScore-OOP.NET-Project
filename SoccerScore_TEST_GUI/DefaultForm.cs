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
            this.pbLoading.BringToFront();
            this.btnClearAllAndExit.Enabled = false;
            this.pbLoading.Visible = true;

            await dataManager.LoadFavouriteTeam();

            foreach (var player in dataManager.FavouriteTeam.AllPlayers)
            {
                PlayerView playerViewControl = new PlayerView(player);

                playerViewControl.FavoutitePlayerAdded += PlayerViewControl_FavoutitePlayerAdded;
                playerViewControl.FavouritePlayerRemoved += PlayerViewControl_FavouritePlayerRemoved;

                //Add drag and drop functionality

                if (player.IsFavourite)
                    this.favoruitePLayersContainer.Controls.Add(playerViewControl);
                else
                    this.playersContainer.Controls.Add(playerViewControl);
            }

            this.lblTitle.Text = $"{dataManager.FavouriteTeam.Details()}";

            Tools.CenterControlInParentHorizontally(this.lblTitle);

            this.pbLoading.Visible = false;
            this.btnClearAllAndExit.Enabled = true;
            this.optionsStrip.Enabled = true;
            this.toolStrip.Enabled = true;

            SetAllControlsVisible();
        }

        private void SetAllControlsVisible()
        {
            this.lblTitle.Visible = true;
            this.playersContainer.Visible = true;
            this.favoruitePLayersContainer.Visible = true;
            this.label1.Visible = true;
            this.label2.Visible = true;
        }

        private void PlayerViewControl_FavouritePlayerRemoved(object sender, EventArgs args)
        {
            PlayerView playerViewToRemove = ((PlayerView)sender);
            this.playersContainer.Controls.Add(playerViewToRemove);

            //Make it deprecated
            dataManager.RemovePlayerFromFavoruites(playerViewToRemove.Player);
        }

        private void PlayerViewControl_FavoutitePlayerAdded(object sender, EventArgs args)
        {
            PlayerView newFavoruitePlayerView = ((PlayerView)sender);
            if (dataManager.HasMaxAmountOfFavoruitePlayers()) //Make into one bool func
            {
                newFavoruitePlayerView.Player.IsFavourite = false;
                MessageBox.Show("You can only have 3 Favoruite players", "" ,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.favoruitePLayersContainer.Controls.Add(newFavoruitePlayerView);

            //Make it deprecated
            dataManager.AddFavouritePlayer(newFavoruitePlayerView.Player);
        }

        private void btnClearAllAndExit_Click(object sender, EventArgs e)
        {
            dataManager.ResetSettingsAndSave();
            Application.Exit();
        }

        //Save all at exit!
    }
}
