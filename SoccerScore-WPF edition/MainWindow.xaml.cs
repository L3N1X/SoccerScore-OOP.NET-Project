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
            this.DataManager = new DataManager();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeControlsForDataManagerFromSettings();
        }

        private async void InitializeControlsForDataManagerFromSettings()
        {
            this.lbOpponentFifaCodes.SelectionChanged -= MatchChanged;

            await DataManager.InitializeDataAsync();

            DataManager.GetOpponentsFifaCodes()
                .ToList().
                ForEach(fifaCode => 
                this.lbOpponentFifaCodes.Items.Add(fifaCode));

            this.lblFavouriteTeamCountryName.Content = this.DataManager.FavouriteTeam.Country;
            this.lblFavouriteTeamCountryName.Opacity = 1;
            this.lbOpponentFifaCodes.SelectedIndex = 0;

            var selectedMatch = DataManager.GetMatchByOpponentFifaCode(this.lbOpponentFifaCodes.SelectedItem as string);

            var selectionTeams = await DataManager.GetSelectionTeams();

            selectionTeams
                .ToList()
                .ForEach(team => this.cbSelectionTeams.Items.Add(team));
            this.cbSelectionTeams.SelectedIndex = this.cbSelectionTeams.Items.IndexOf(DataManager.FavouriteTeam);

            FillControlsWithMatchData(selectedMatch);
            this.lbOpponentFifaCodes.SelectionChanged += MatchChanged;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.lbOpponentFifaCodes.SelectionChanged -= MatchChanged;

            NationalTeam selectedTeam = this.cbSelectionTeams.SelectedItem as NationalTeam;
            this.DataManager.ResetFavourtiteTeamSettings();
            this.DataManager.SetFavouriteTeam(selectedTeam);

            this.cbSelectionTeams.Items.Clear();
            this.lbOpponentFifaCodes.Items.Clear();

            InitializeControlsForDataManagerFromSettings();
        }

        private void MatchChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedMatch = DataManager.GetMatchByOpponentFifaCode(this.lbOpponentFifaCodes.SelectedItem as string);
            FillControlsWithMatchData(selectedMatch);
        }

        private void FillControlsWithMatchData(Match match)
        {
            this.lblMatchInfo.Content = $"{match.HomeTeam.Country} {match.HomeTeam.MatchGoals}:{match.AwayTeam.MatchGoals} {match.AwayTeam.Country}";
            ClearPlayersGrid();
            foreach (var player in match.HomeTeamStatistics.StartingEleven)
            {
                switch (player.Position)
                {
                    case Position.Goalie:
                        this.pnlHomeGoalie.Children.Add(new Button() { Content = $"{player.Name}{Environment.NewLine}{player.ShirtNumber}", Style = this.FindResource("PlayerButtonStyle") as Style });
                        break;
                    case Position.Defender:
                        this.pnlHomeDefence.Children.Add(new Button() { Content = $"{player.Name}{Environment.NewLine}{player.ShirtNumber}", Style = this.FindResource("PlayerButtonStyle") as Style});
                        break;
                    case Position.Forward:
                        this.pnlHomeForward.Children.Add(new Button() { Content = $"{player.Name}{Environment.NewLine}{player.ShirtNumber}", Style = this.FindResource("PlayerButtonStyle") as Style });
                        break;
                    case Position.Midfield:
                        this.pnlHomeMidfield.Children.Add(new Button() { Content = $"{player.Name}{Environment.NewLine}{player.ShirtNumber}", Style = this.FindResource("PlayerButtonStyle") as Style });
                        break;
                }
            }
            foreach (var player in match.AwayTeamStatistics.StartingEleven)
            {
                switch (player.Position)
                {
                    case Position.Goalie:
                        this.pnlAwayGoalie.Children.Add(new Button() { Content = $"{player.Name}{Environment.NewLine}{player.ShirtNumber}", Style = this.FindResource("PlayerButtonStyle") as Style });
                        break;
                    case Position.Defender:
                        this.pnlAwayDefence.Children.Add(new Button() { Content = $"{player.Name}{Environment.NewLine}{player.ShirtNumber}", Style = this.FindResource("PlayerButtonStyle") as Style });
                        break;
                    case Position.Forward:
                        this.pnlAwayForward.Children.Add(new Button() { Content = $"{player.Name}{Environment.NewLine}{player.ShirtNumber}", Style = this.FindResource("PlayerButtonStyle") as Style });
                        break;
                    case Position.Midfield:
                        this.pnlAwayMidfield.Children.Add(new Button() { Content = $"{player.Name}{Environment.NewLine}{player.ShirtNumber}", Style = this.FindResource("PlayerButtonStyle") as Style });
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
    }
}