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
            this.playersContainer.Visible = false;
            this.pbLoading.Visible = true;
            await dataManager.LoadFavouriteTeam();
            foreach (var player in dataManager.FavouriteTeam.AllPlayers)
            {
                this.playersContainer.Controls.Add(new PlayerView(player));
            }

            this.lblNationalTeam.Text = $"[{dataManager.FavouriteTeam.FifaCode}]{Environment.NewLine}{dataManager.FavouriteTeam.Details()}";
            this.lblStatistics.Text = $"Wins: {dataManager.FavouriteTeam.Wins}{Environment.NewLine}" +
                $"Losses: {dataManager.FavouriteTeam.Losses}{Environment.NewLine}" + 
                $"Points: {dataManager.FavouriteTeam.Points}";

            this.pbLoading.Visible = false;
            this.playersContainer.Visible = true;

        }
        
    }
}
