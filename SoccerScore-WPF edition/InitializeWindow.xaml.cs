﻿using SoccerScoreData.Dal;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SoccerScore_WPF_edition
{
    /// <summary>
    /// Interaction logic for InitializeWindow.xaml
    /// </summary>
    public partial class InitializeWindow : Window
    {
        private DataManager _dataManager;
        public InitializeWindow(DataManager dataManager)
        {
            _dataManager = dataManager;
            /*Localization and globalization*/
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_dataManager.GetLanguage().ToString());
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(_dataManager.GetLanguage().ToString());
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.cbSelectionTeams.Items.Clear();
            if (_dataManager?.FavouriteTeam?.TeamGender == Gender.Male)
            {
                this.rbMale.IsChecked = true;
            }
            else
                this.rbFemale.IsChecked = true;
            try
            {
                this.pnlLoading.Visibility = Visibility.Visible;
                FillSelectionTeams();
                this.pnlLoading.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.lblDataSource.Content = _dataManager.DataSource.ToString();
        }

        private async void FillSelectionTeams()
        {
            this?.cbSelectionTeams?.Items?.Clear();
            var selectionTeams = await _dataManager.GetSelectionTeams();
            foreach (var team in selectionTeams)
            {
                this.cbSelectionTeams.Items.Add(team);
            }
            this.cbSelectionTeams.SelectedIndex = 0;
        }

        private void GenderButton_Click(object sender, RoutedEventArgs e)
        {
            _dataManager.SetGender((Gender)Enum.Parse(typeof(Gender), (sender as RadioButton).Tag.ToString()));
            this.FillSelectionTeams();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            _dataManager.ResetFavourtiteTeamSettings();
            _dataManager.SetFavouriteTeam(this.cbSelectionTeams.SelectedItem as NationalTeam);
            _dataManager.SetWindowPropertiesWPF(GetWidthSelection(), GetHeightSelection(), (bool)(this?.rbFullscreen?.IsChecked));
            this.DialogResult = true;
            Close();
        }

        private int GetWidthSelection()
        {
            // MinHeight="578" MinWidth="956"
            if ((bool)(this?.rbSmall?.IsChecked))
                return 956;
            else if ((bool)(this?.rbMedium?.IsChecked))
                return 1000;
            else if ((bool)(this?.rbLarge?.IsChecked))
                return 1200;
            else
                return 956;
        }

        private int GetHeightSelection()
        {
            // MinHeight="578" MinWidth="956"
            if ((bool)(this?.rbSmall?.IsChecked))
                return 578;
            else if ((bool)(this?.rbMedium?.IsChecked))
                return 600;
            else if ((bool)(this?.rbLarge?.IsChecked))
                return 800;
            else
                return 578;
        }

        private void Cro_Click(object sender, MouseButtonEventArgs e)
        {
            _dataManager.SetLanguage(SoccerScoreData.Models.Language.hr);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_dataManager.GetLanguage().ToString());
        }

        private void Eng_Click(object sender, MouseButtonEventArgs e)
        {
            _dataManager.SetLanguage(SoccerScoreData.Models.Language.eng);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_dataManager.GetLanguage().ToString());
        }
    }
}
