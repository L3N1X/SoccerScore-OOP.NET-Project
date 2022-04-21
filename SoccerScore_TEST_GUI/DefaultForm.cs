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
                PlayerView playerViewControl = new PlayerView(player);
                playerViewControl.FavoutitePlayerAdded += PlayerViewControl_FavoutitePlayerAdded;
                this.playersContainer.Controls.Add(playerViewControl);
            }
            this.pbLoading.Visible = false;
            this.playersContainer.Visible = true;
            this.favoruitePLayersContainer.Visible = true;
        }

        private void PlayerViewControl_FavoutitePlayerAdded(object sender, EventArgs args)
        {
            MessageBox.Show($"Added to favoruites: {((PlayerView)sender).Player.Name}");
        }
    }
}
