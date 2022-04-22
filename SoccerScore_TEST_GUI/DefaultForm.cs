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
        internal DataManager dataManager;
        public DefaultForm()
        {
            InitializeComponent();
            Tools.CenterControlInParent(this.pbLoading);
        }

        private void DefaultForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataManager = new DataManager();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
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
            this.pbLoading.Visible = true;

            await dataManager.LoadFavouriteTeam();

            foreach (var player in dataManager.FavouriteTeam.AllPlayers)
            {
                this.lbPlayers.Items.Add(player.ListBoxDetails());

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

            this.lblCountry.Text = dataManager.FavouriteTeam.Country;
            this.lblFifaCode.Text = dataManager.FavouriteTeam.FifaCode;
            this.lblGamesPlayed.Text = dataManager.FavouriteTeam?.GamesPlayed.ToString();
            this.lblGoalsFor.Text = dataManager.FavouriteTeam?.GoalsFor.ToString();
            this.lblLosses.Text = dataManager.FavouriteTeam?.Losses.ToString();
            this.lblTotalPoints.Text = dataManager.FavouriteTeam.Points.ToString();
            this.lblWins.Text = dataManager.FavouriteTeam?.Wins.ToString();
            this.lblDraws.Text = dataManager?.FavouriteTeam?.Draws.ToString();
            this.lblGoalsAgainst.Text = dataManager?.FavouriteTeam?.GoalsAgainst.ToString();
            this.lblGoalDifferential.Text = dataManager?.FavouriteTeam.GoalDifferential.ToString();

            Tools.CenterControlInParentHorizontally(this.lblTitle);

            this.pbLoading.Visible = false;
            this.optionsStrip.Enabled = true;
            this.toolStrip.Enabled = true;

            this.lblStatus.Text = dataManager.FavouriteTeam.Details();

            SetAllControlsVisible();
        }

        private void SetAllControlsVisible()
        {
            this.lblTitle.Visible = true;
            this.playersContainer.Visible = true;
            this.favoruitePLayersContainer.Visible = true;
            this.label1.Visible = true;
            this.label2.Visible = true;
            this.pbBorderLeft.Visible = true;
            this.pbBorderRight.Visible = true;
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
                MessageBox.Show("You can only have 3 Favoruite players", "Info" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.favoruitePLayersContainer.Controls.Add(newFavoruitePlayerView);

            //Make it deprecated
            dataManager.AddFavouritePlayer(newFavoruitePlayerView.Player);
        }

        private void btnClearAllAndExit_Click(object sender, EventArgs e)
        {
            
        }

        private void DefaultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = (new ExitForm()).ShowDialog();
            switch (result)
            {
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private void clearAndExitOption_Click(object sender, EventArgs e)
        {
            dataManager.ResetSettingsAndSave();
            Close();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {

        }

        private void btnCroatian_Click(object sender, EventArgs e)
        {

        }
    }
}
