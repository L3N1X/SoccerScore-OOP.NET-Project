using SoccerScoreData.Dal;
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
            InitializeDataManagerAsync();
        }

        private async void InitializeDataManagerAsync()
        {
            await DataManager.InitializeData();

            DataManager.GetOpponentsFifaCodes()
                .ToList().
                ForEach(fifaCode => 
                this.lbOpponentFifaCodes.Items.Add(fifaCode));

            this.lblFavouriteTeamCountryName.Content = this.DataManager.FavouriteTeam.Country;
            this.lblFavouriteTeamCountryName.Opacity = 1;
            this.lbOpponentFifaCodes.SelectedIndex = 0;
        }

        private void MatchChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
