﻿using SoccerScoreData.Dal;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerScore_TEST_GUI
{
    public partial class DefaultForm : Form
    {
        internal DataManager dataManager;
        public DefaultForm()
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
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.DefaultForm_FormClosing);
                    Close();
                }
                    
            }
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(dataManager.GetLanguage().ToString());
            Thread.CurrentThread.CurrentCulture = new CultureInfo(dataManager.GetLanguage().ToString());
            InitializeComponent();
        }

        private void DefaultForm_Load(object sender, EventArgs e)
        {
            InitializeControlsWithData();
        }

        //Blend to one function
        private async void InitializeControlsWithData()
        {
            Tools.CenterControlInParent(this.pbLoading);
            this.pbLoading.BringToFront();
            this.pbLoading.Visible = true;

            await dataManager.InitializeDataAsync();

            this.FillControls();
            this.SetAllControlsVisible();
        }

        private void InitializeControlsWithoutData()
        {
            Tools.CenterControlInParent(this.pbLoading);
            this.pbLoading.BringToFront();
            this.pbLoading.Visible = true;
            this.FillControls();
            SetAllControlsVisible();
        }

        private void FillControls()
        {
            foreach (var player in dataManager.FavouriteTeam.AllPlayers)
            {
                this.lbPlayers.Items.Add(player.ListBoxDetails());

                PlayerView playerViewControl = new PlayerView(player, dataManager.FavouriteTeam);

                playerViewControl.FavoutitePlayerAdded += PlayerViewControl_FavoutitePlayerAdded;
                playerViewControl.FavouritePlayerRemoved += PlayerViewControl_FavouritePlayerRemoved;

                /*Not operational*/
                //playerViewControl.MouseDown += PlayerViewControl_MouseDown;

                //this.favoruitePLayersContainer.DragDrop += Container_DragDrop;
                //this.favoruitePLayersContainer.DragEnter += ContainerDragEnter;

                //this.playersContainer.DragDrop += Container_DragDrop;
                //this.playersContainer.DragEnter += ContainerDragEnter;
                /*Not operational*/

                if (player.IsFavourite)
                    this.favoruitePLayersContainer.Controls.Add(playerViewControl);
                else
                    this.playersContainer.Controls.Add(playerViewControl);
            }

            foreach (var match in dataManager.FavouriteTeamMatches)
            {
                this.flpMatches.Controls.Add(new MatchView(match, dataManager.FavouriteTeam));
            }

            if (CultureInfo.CurrentCulture.Name == Language.eng.ToString())
                this.lblTitle.Text = $"{dataManager.FavouriteTeam.Country} - {(dataManager.FavouriteTeam.TeamGender == Gender.Male ? "men's" : "women's")} national team";
            else if (CultureInfo.CurrentCulture.Name == Language.hr.ToString())
                this.lblTitle.Text = $"{dataManager.FavouriteTeam.Country} - {(dataManager.FavouriteTeam.TeamGender == Gender.Male ? "muška" : "ženska")} nogometna reprezentacija";

            InitializeLabelText();

            /**/
            var allPlayers = new List<Player>(dataManager.FavouriteTeam.StartingEleven);
            foreach (var substitute in dataManager.FavouriteTeam.Substitutes)
            {
                allPlayers.Add(substitute);
            }
            var playersByYellowCards = new List<Player>(allPlayers);
            playersByYellowCards.Sort((left, right) => -left.YellowCards.CompareTo(right.YellowCards));
            var playersByGoals = new List<Player>(allPlayers);
            playersByGoals.Sort((left, right) => -left.Goals.CompareTo(right.Goals));
            foreach (var player in playersByYellowCards)
            {
                PlayerViewRankView playerViewControl = new PlayerViewRankView(player, dataManager.FavouriteTeam, "yellowcards");
                this.flpPlayersYellowCards.Controls.Add(playerViewControl);
            }
            foreach (var player in playersByGoals)
            {
                PlayerViewRankView playerViewControl = new PlayerViewRankView(player, dataManager.FavouriteTeam, "goals");
                this.flpPlayersGoals.Controls.Add(playerViewControl);
            }
            /**/

            Tools.CenterControlInParentHorizontally(this.lblTitle);

            this.pbCountryLeft.Image = CountryImages.ResourceManager.GetObject(dataManager.FavouriteTeam.FifaCode) as Image;
            this.pbCountryRight.Image = CountryImages.ResourceManager.GetObject(dataManager.FavouriteTeam.FifaCode) as Image;
            this.pbCountryStatistics.Image = CountryImages.ResourceManager.GetObject(dataManager.FavouriteTeam.FifaCode) as Image;

            this.pbLoading.Visible = false;
            this.toolStrip.Enabled = true;

            this.lblStatus.Text = lblTitle.Text;
        }

        private void InitializeLabelText()
        {
            this.lblCountry.Text = dataManager.FavouriteTeam.Country.ToString();
            this.lblFifaCode.Text = dataManager.FavouriteTeam.FifaCode.ToString();
            this.lblGamesPlayed.Text = dataManager.FavouriteTeam?.GamesPlayed.ToString();
            this.lblGoalsFor.Text = dataManager.FavouriteTeam?.GoalsFor.ToString();
            this.lblLosses.Text = dataManager.FavouriteTeam?.Losses.ToString();
            this.lblTotalPoints.Text = dataManager.FavouriteTeam.Points.ToString();
            this.lblWins.Text = dataManager.FavouriteTeam?.Wins.ToString();
            this.lblDraws.Text = dataManager?.FavouriteTeam?.Draws.ToString();
            this.lblGoalsAgainst.Text = dataManager?.FavouriteTeam?.GoalsAgainst.ToString();
            this.lblGoalDifferential.Text = dataManager?.FavouriteTeam.GoalDifferential.ToString();
        }

        private void SetAllControlsVisible()
        {
            this.pbCountryLeft.Visible = true;
            this.pbCountryRight.Visible = true;
            this.lblTitle.Visible = true;
            this.playersContainer.Visible = true;
            this.favoruitePLayersContainer.Visible = true;
            this.label1.Visible = true;
            this.label2.Visible = true;
            this.pbBorderLeft.Visible = true;
            this.pbBorderRight.Visible = true;
            this.pbField1.Visible = true;
            this.pbField2.Visible = true;
            this.pnlTitle.Visible = true;
        }

        /*Not operational*/
        private Control dragableControl;

        private void PlayerViewControl_MouseDown(object sender, MouseEventArgs e)
        {
            StartDragAndDrop(sender as PlayerView);
            MessageBox.Show("aaa");
        }

        private void StartDragAndDrop(PlayerView playerView)
        {
            dragableControl = playerView;
            playerView.DoDragDrop(playerView, DragDropEffects.Move);
        }

        private void ContainerDragEnter(object sender, DragEventArgs e)
        {
            PlayerView playerView = sender as PlayerView;
            e.Effect = DragDropEffects.Move;
        }

        /*Not operational*/

        private void PlayerViewControl_FavouritePlayerRemoved(object sender, EventArgs args)
        {
            PlayerView playerViewToRemove = ((PlayerView)sender);
            this.playersContainer.Controls.Add(playerViewToRemove);
            dataManager.RemovePlayerFromFavoruites(playerViewToRemove.Player);
        }

        private void PlayerViewControl_FavoutitePlayerAdded(object sender, EventArgs args)
        {
            PlayerView newFavoruitePlayerView = sender as PlayerView;
            if (dataManager.HasMaxAmountOfFavoruitePlayers())
            {
                newFavoruitePlayerView.Player.IsFavourite = false;
                new FavouritePlayersExceededForm().ShowDialog();
                return;
            }
            this.favoruitePLayersContainer.Controls.Add(newFavoruitePlayerView);
            dataManager.AddFavouritePlayer(newFavoruitePlayerView.Player);
        }

        private void DefaultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = (new ExitForm()).ShowDialog();
            switch (result)
            {
                case DialogResult.Yes:
                    SavePlayerImages();
                    dataManager.SaveSettings();
                    break;
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private void SavePlayerImages()
        {
            IList<Player> playersWithImages = new List<Player>();
            foreach (var control in this.playersContainer.Controls)
            {
                if(control is PlayerView playerView && playerView.Player.IconPath != null)
                    playersWithImages.Add(playerView.Player);
            }
            foreach (var control in this.favoruitePLayersContainer.Controls)
            {
                if (control is PlayerView playerView && playerView.Player.IconPath != null)
                    playersWithImages.Add(playerView.Player);
            }
            dataManager.SavePlayersWithImage(playersWithImages);
        }

        private void English_Click(object sender, EventArgs e)
        {
            dataManager.SetLanguage(Language.eng);
            this.SetCulture(dataManager.GetLanguage());
        }

        private void Croatian_Click(object sender, EventArgs e)
        {
            dataManager.SetLanguage(Language.hr);
            this.SetCulture(dataManager.GetLanguage());
        }

        private void SetCulture(Language language)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language.ToString());
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language.ToString());
            UpdateUI();
        }

        private void UpdateUI()
        {
            Controls.Clear();
            //Avoid double subscribing
            this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.DefaultForm_FormClosing);
            InitializeComponent();
            InitializeControlsWithoutData();
        }

        private void SettingsClick(object sender, EventArgs e)
        {
            Form dialog = new InitializeForm(dataManager);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SavePlayerImages();
                Controls.Clear();
                //Avoid double subscribing
                this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.DefaultForm_FormClosing);
                InitializeComponent();
                Tools.CenterControlInParent(this.pbLoading);
                InitializeControlsWithData();
            }
            else
            {
                dialog.Close();
            };
        }

        /*GENERIC PRINTING START*/

        private int printPageCalled = 0;
        private int lastPrintIndex = 0;
        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Control source = cmsOptions.SourceControl;
            if (printPageCalled == 0)
            {
                lastPrintIndex = source.Controls.Count - 1;
            }
            this.printPageCalled++;
            if (this.PrintContent(source, e))
                return;
        }

        private bool PrintContent(Control container, PrintPageEventArgs e)
        {
            int controlWidth = container.Controls[0].Size.Width;
            int controlHeight = container.Controls[0].Size.Height;
            int totalPrintHeight = 0;
            int offset = 0;
            for (int i = this.lastPrintIndex; i >= 0; i--)
            {
                var control = container.Controls[i] as Control;
                Bitmap bmp = new Bitmap(controlWidth, controlHeight);
                control.DrawToBitmap(bmp,
                    new Rectangle
                    {
                        X = 0,
                        Y = 0,
                        Width = bmp.Width,
                        Height = bmp.Height
                    });
                totalPrintHeight += controlHeight;
                if (totalPrintHeight > e.PageSettings.PaperSize.Height)
                {
                    this.lastPrintIndex = i++;
                    e.HasMorePages = true;
                    return e.HasMorePages;
                }
                else
                {
                    e.HasMorePages = false;
                    e.Graphics.DrawImage(bmp, 0, offset * controlHeight);
                }
                offset++;

            }
            return false;
        }

        private void PrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            printPageCalled = 0;
            lastPrintIndex = 0;
        }

        private void PrintOption_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog.ShowDialog();
        }

        private void ConfigurePrinterOption_Click(object sender, EventArgs e)
        {
            this.printDialog.ShowDialog();
        }

        /*GENERIC PRINTING END*/
    }
}
