using SoccerScoreData.Dal;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.cbSelectionTeams.Items.Clear();
            if (_dataManager?.FavouriteTeam?.TeamGender == Gender.Male)
                this.rbMale.IsChecked = true;
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

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            _dataManager.ResetFavourtiteTeamSettings();
            _dataManager.SetFavouriteTeam(this.cbSelectionTeams.SelectedItem as NationalTeam);
            Close();
        }

        private void btnCro_Click(object sender, RoutedEventArgs e)
        {
            _dataManager.SetLanguage(SoccerScoreData.Models.Language.hr);
        }

        private void btnEng_Click(object sender, RoutedEventArgs e)
        {
            _dataManager.SetLanguage(SoccerScoreData.Models.Language.eng);
        }
    }
}
