﻿using SoccerScoreData.Dal;
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
            InitializeComponent();
            this.dataManager = dataManager;
        }

        private async void FillSelectionTeams()
        {
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
            this.UpdateConfirmButtonText();
            this.btnConfirm.Enabled = true;
        }

        private void UpdateConfirmButtonText()
        {
            this.btnConfirm.Text = $"Select{Environment.NewLine}{((NationalTeam)this.cbNationalTeams.SelectedItem).Details()}";
        }

        private void InitializeForm_Load(object sender, EventArgs e)
        {
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

        private void cbNationalTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateConfirmButtonText();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.dataManager.SetFavouriteTeam(this.cbNationalTeams.SelectedItem as NationalTeam);
            this.LoadFavouriteTeam();
        }

        private async void LoadFavouriteTeam()
        {
            this.btnConfirm.Enabled = false;
            this.cbNationalTeams.Enabled = false;
            this.rbFemale.Enabled = false;
            this.rbMale.Enabled = false;
            this.pbLoading.Image = Images.loading;
            await this.dataManager.LoadFavouriteTeam();
            this.pbLoading.Image = null;
            this.Close();
        }
    }
}