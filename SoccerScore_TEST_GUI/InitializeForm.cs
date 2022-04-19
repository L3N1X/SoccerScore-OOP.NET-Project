using SoccerScoreData.Dal;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerScore_TEST_GUI
{
    public partial class InitializeForm : Form
    {
        DataManager dm = new DataManager();
        public InitializeForm()
        {
            InitializeComponent();
            dm.Initialize();
        }

        private async void FillSelectionTeams()
        {
            this.cbNationalTeams.Items.Clear();
            this.cbNationalTeams.Enabled = false;
            var selectionTeams = await dm.GetSelectionTeams();
            foreach (var team in selectionTeams)
            {
                this.cbNationalTeams.Items.Add(team);
            }
            this.cbNationalTeams.SelectedIndex = 0;
            this.cbNationalTeams.Enabled = true;
        }

        private void cbNationalTeams_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InitializeForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.FillSelectionTeams();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenderButton_Click(object sender, EventArgs e)
        {
            this.dm.SetGender((Gender)Enum.Parse(typeof(Gender), (sender as RadioButton).Tag.ToString()));
            this.FillSelectionTeams();
        }

        private void gbInitialize_Enter(object sender, EventArgs e)
        {

        }
    }
}
