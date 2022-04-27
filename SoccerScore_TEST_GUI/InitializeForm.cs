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
        private DataManager dataManager;
        public InitializeForm(DataManager dataManager)
        {
            this.dataManager = dataManager;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(dataManager.GetLanguage().ToString());
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(dataManager.GetLanguage().ToString());
            InitializeComponent();
        }

        private async void FillSelectionTeams()
        {
            Tools.CenterControlInParentHorizontally(this.rbFemale);
            Tools.CenterControlInParentHorizontally(this.rbMale);
            Tools.CenterControlInParentHorizontally(this.label1);
            Tools.CenterControlInParentHorizontally(this.lblLanguage);

            this.pbLoading.Visible = true;
            this.btnConfirm.Enabled = false;
            this.cbNationalTeams.Items.Clear();
            this.cbNationalTeams.Enabled = false;
            var selectionTeams = await dataManager.GetSelectionTeams();
            foreach (var team in selectionTeams)
            {
                this.cbNationalTeams.Items.Add(team);
            }
            this.cbNationalTeams.SelectedIndex = 0;
            this.cbNationalTeams.Enabled = true;
            this.pbLoading.Visible = false;
            this.btnConfirm.Enabled = true;
        }

        private void InitializeForm_Load(object sender, EventArgs e)
        {
            this.cbNationalTeams.Items.Clear();
            if(dataManager?.FavouriteTeam?.TeamGender == Gender.Male)
                this.rbMale.Checked = true;
            else
                this.rbFemale.Checked = true;
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
            this.dataManager.SetGender((Gender)Enum.Parse(typeof(Gender), (sender as RadioButton).Tag.ToString()));
            this.FillSelectionTeams();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.dataManager.SetFavouriteTeam(this.cbNationalTeams.SelectedItem as NationalTeam);
            Close();
        }

        private void pbEnglish_Click(object sender, EventArgs e)
        {
            this.dataManager.SetLanguage(Language.eng);
            SetLanguage();
        }

        private void pbCroatian_Click(object sender, EventArgs e)
        {
            this.dataManager.SetLanguage(Language.hr);
            SetLanguage();
        }

        private void SetLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(dataManager.GetLanguage().ToString());
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(dataManager.GetLanguage().ToString());
            UpdateUI();
        }

        private void UpdateUI()
        {
            this.Controls.Clear();
            InitializeComponent();
            FillSelectionTeams();
        }
    }
}
