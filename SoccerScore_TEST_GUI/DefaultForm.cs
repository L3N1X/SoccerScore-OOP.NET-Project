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
            CenterControlInParent(this.pbLoading);
        }

        private void DefaultForm_Load(object sender, EventArgs e)
        {
            if (dataManager.HasDefaultSettings())
            {
                Form dialog = new InitializeForm(dataManager);
                dialog.ShowDialog();
            }
            FillPlayers();
        }

        private async void FillPlayers()
        {
            this.pbLoading.Visible = true;
            await dataManager.LoadFavouriteTeam();
            this.pbLoading.Visible = false;
            foreach (var player in dataManager.FavouriteTeam.AllPlayers)
            {
                this.playersContainer.Controls.Add(new PlayerView(player));
            }
        }

        //Extract to utils
        private void CenterControlInParent(Control control)
        {
            control.Left = (control.Parent.Width - control.Width) / 2;
            control.Top = (control.Parent.Height - control.Height) / 2;
        }
    }
}
