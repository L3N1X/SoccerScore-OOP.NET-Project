using SoccerScore_WPF_edition.Models.ViewModels;
using SoccerScoreData.Dal;
using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoccerScore_WPF_edition
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataManager DataManager { get; private set; }
        public MainWindow()
        {
            try
            {
                this.DataManager = new DataManager();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (DataManager.HasDefaultSettings())
            {
                Window dialog = new InitializeWindow(DataManager);
                dialog.ShowDialog();
                /*Unsubscribe closed event if necessary*/
            }
            /*Localization and globalization*/
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeControls();
            SetWindowPropertiesFromSettings();
        }

        private void SetWindowPropertiesFromSettings()
        {
            this.Height = DataManager.WindowHeight;
            this.Width = DataManager.WindowWidth;
            this.WindowState = DataManager.IsFullScreen ? WindowState.Maximized : WindowState.Normal;
        }

        private async void InitializeControls()
        {
            ClearPlayersGrid();
            this.gwTeamSelection.Opacity = 0;
            this.loadingCanvas.Visibility = Visibility.Visible;
            this.gwMatch.Opacity = 0;
            this.pnlTeamInfo.Opacity = 0;

            this.lbOpponentFifaCodes.SelectionChanged -= MatchChanged;
            this.cbSelectionTeams.SelectionChanged -= FavoruiteTeamChanged;
            this.lbOpponentFifaCodes.Items.Clear();
            this.cbSelectionTeams.Items.Clear();

            await DataManager.InitializeDataAsync();

            DataManager.GetOpponentsFifaCodes()
                .ToList().
                ForEach(fifaCode => 
                this.lbOpponentFifaCodes.Items.Add(new MatchListItemViewModel { FifaCode = fifaCode }));

            this.lblFavouriteTeamCountryName.Content = this.DataManager.FavouriteTeam.Country;
            this.lblFavouriteTeamCountryName.Opacity = 1;
            this.lbOpponentFifaCodes.SelectedIndex = 0;

            var selectedMatch = DataManager.GetMatchByOpponentFifaCode((this.lbOpponentFifaCodes.SelectedItem as MatchListItemViewModel).FifaCode);

            var selectionTeams = await DataManager.GetSelectionTeams();

            selectionTeams
                .ToList()
                .ForEach(team => this.cbSelectionTeams.Items.Add(team));
            this.cbSelectionTeams.SelectedIndex = this.cbSelectionTeams.Items.IndexOf(DataManager.FavouriteTeam);

            FillControlsWithMatchData(selectedMatch);

            this.lbOpponentFifaCodes.SelectionChanged += MatchChanged;
            this.cbSelectionTeams.SelectionChanged += FavoruiteTeamChanged;

            this.imgFavouriteTeamCountry.Source = new BitmapImage(new Uri($"Content/CountryImages/{DataManager.FavouriteTeam.FifaCode}.jpg", UriKind.Relative));
            this.lblFavouriteTeamCountryName.Content = DataManager.FavouriteTeam.Country;

            this.lblGender.Text = DataManager.SelectedGender.ToString();
            this.lblGender.Background = DataManager.SelectedGender.Equals(Gender.Male) ? Brushes.DarkBlue : Brushes.HotPink;

            //this.gwPlayerPositions.Opacity = 1;
            this.gwMatch.Opacity = 1;
            this.pnlTeamInfo.Opacity = 1;
            this.loadingCanvas.Visibility = Visibility.Hidden;
            this.gwTeamSelection.Opacity = 1;
        }

        private void FavoruiteTeamChanged(object sender, SelectionChangedEventArgs e)
        {
            this.lbOpponentFifaCodes.SelectionChanged -= MatchChanged;
            this.cbSelectionTeams.SelectionChanged -= FavoruiteTeamChanged;

            NationalTeam selectedTeam = this.cbSelectionTeams.SelectedItem as NationalTeam;
            this.DataManager.ResetFavourtiteTeamSettings();
            this.DataManager.SetFavouriteTeam(selectedTeam);

            this.cbSelectionTeams.Items.Clear();
            this.lbOpponentFifaCodes.Items.Clear();

            InitializeControls();
        }

        private void MatchChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedMatch = DataManager.GetMatchByOpponentFifaCode((this.lbOpponentFifaCodes.SelectedItem as MatchListItemViewModel).FifaCode);
            FillControlsWithMatchData(selectedMatch);
        }

        private void FillControlsWithMatchData(Match match)
        {
            ClearPlayersGrid();
            this.lblHomeCountry.Text = match.HomeTeam.Country;
            this.lblAwayCountry.Text = match.AwayTeam.Country; 
            this.lblResult.Text = $"{match.HomeTeam.MatchGoals} : {match.AwayTeam.MatchGoals}";
            this.lblStadium.Text = match.Location;
            this.imgHomeCountry.Source = new BitmapImage(new Uri($"Content/CountryImages/{match.HomeTeam.FifaCode}.jpg", UriKind.Relative));
            this.imgAwayCountry.Source = new BitmapImage(new Uri($"Content/CountryImages/{match.AwayTeam.FifaCode}.jpg", UriKind.Relative));
            this.HomeTeamInfo.Tag = match.HomeTeam.FifaCode;
            this.AwayTeamInfo.Tag = match.AwayTeam.FifaCode;

            foreach (var player in match.HomeTeamStatistics.StartingEleven)
            {
                switch (player.Position)
                {
                    case Position.Goalie:
                        this.pnlHomeGoalie.Children.Add(new PlayerControl(player: player, isHome: true));
                        break;
                    case Position.Defender:
                        this.pnlHomeDefence.Children.Add(new PlayerControl(player: player, isHome: true));
                        break;
                    case Position.Forward:
                        this.pnlHomeForward.Children.Add(new PlayerControl(player: player, isHome: true));
                        break;
                    case Position.Midfield:
                        this.pnlHomeMidfield.Children.Add(new PlayerControl(player: player, isHome: true));
                        break;
                }
            }
            foreach (var player in match.AwayTeamStatistics.StartingEleven)
            {
                switch (player.Position)
                {
                    case Position.Goalie:
                        this.pnlAwayGoalie.Children.Add(new PlayerControl(player: player, isHome: false));
                        break;
                    case Position.Defender:
                        this.pnlAwayDefence.Children.Add(new PlayerControl(player: player, isHome: false));
                        break;
                    case Position.Forward:
                        this.pnlAwayForward.Children.Add(new PlayerControl(player: player, isHome: false));
                        break;
                    case Position.Midfield:
                        this.pnlAwayMidfield.Children.Add(new PlayerControl(player: player, isHome: false));
                        break;
                }
            }
        }

        private void ClearPlayersGrid()
        {
            this.pnlHomeGoalie.Children.Clear();
            this.pnlHomeDefence.Children.Clear();
            this.pnlHomeMidfield.Children.Clear();
            this.pnlHomeForward.Children.Clear();
            this.pnlAwayGoalie.Children.Clear();
            this.pnlAwayDefence.Children.Clear();
            this.pnlAwayMidfield.Children.Clear();
            this.pnlAwayForward.Children.Clear();
        }

        private void TeamInfoClicked(object sender, MouseButtonEventArgs e)
        {
            string fifacode = (string)(sender as Image).Tag;
            new NationalTeamWindow(this.DataManager, fifacode).ShowDialog();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you wan't to exit?", "SoccerScore", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DataManager.SetWindowPropertiesWPF((int)this.Width, (int)this.Height, this.WindowState.Equals(WindowState.Maximized) ? true : false);
                DataManager.SaveSettings();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Settings_Click(object sender, MouseButtonEventArgs e)
        {
            InitializeWindow window = new InitializeWindow(DataManager);
            bool? result = window.ShowDialog();
            if (result ?? true)
            {
                InitializeControls();
                SetWindowPropertiesFromSettings();
            }
        }
    }
}