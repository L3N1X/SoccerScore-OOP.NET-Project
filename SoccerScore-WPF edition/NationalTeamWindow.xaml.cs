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
    /// Interaction logic for NationalTeamWindow.xaml
    /// </summary>
    public partial class NationalTeamWindow : Window
    {
        private readonly DataManager _dataManager;
        private readonly string _fifaCode;

        private NationalTeam _nationalTeam;
        public NationalTeamWindow(DataManager dataManager, string fifaCode)
        {
            _dataManager = dataManager;
            _fifaCode = fifaCode;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeControls();
        }

        private async void InitializeControls()
        {
            SetVisibilityForLoading();

            if (_fifaCode.Equals(_dataManager.FavouriteTeam.FifaCode))
                _nationalTeam = _dataManager.FavouriteTeam;
            else
            {
                var teams = await _dataManager.GetSelectionTeams();
                _nationalTeam = teams.Where(team => _fifaCode.Equals(team.FifaCode)).ToList()[0];
            }
            FillTeamData();

            SetVisibiltyAfterLoading();
        }

        private void FillTeamData()
        {
            this.lblFifaCode.Content = _nationalTeam.FifaCode;
            this.lblDraws.Content = _nationalTeam.Draws;
            this.lblGamesPlayed.Content = _nationalTeam.GamesPlayed;
            this.lblGoalDifferential.Content = _nationalTeam.GoalDifferential;
            this.lblGoalsAgainst.Content = _nationalTeam.GoalsAgainst;
            this.lblGoalsFor.Content = _nationalTeam.GoalsFor;
            this.lblLosses.Content = _nationalTeam.Losses;
            this.lblTotalPoints.Content = _nationalTeam.Points;
            this.lblWins.Content = _nationalTeam.Wins;
        }

        private void SetVisibiltyAfterLoading()
        {
            this.pnlLoading.Visibility = Visibility.Hidden;
            this.pnlFlag.Visibility = Visibility.Visible;
            this.pnlTeamData.Visibility = Visibility.Visible;
        }

        private void SetVisibilityForLoading()
        {
            this.pnlLoading.Visibility = Visibility.Visible;
            this.pnlFlag.Visibility = Visibility.Hidden;
            this.pnlTeamData.Visibility = Visibility.Hidden;
        }
    }
}
