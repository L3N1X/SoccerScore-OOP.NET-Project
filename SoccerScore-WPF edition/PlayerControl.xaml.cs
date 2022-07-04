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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoccerScore_WPF_edition
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        private Player _player;
        public PlayerControl()
        {
            InitializeComponent();
        }

        public PlayerControl(Player player, bool isHome) : this()
        {
            _player = player;
            this.lblPlayerName.Content = player.Name;
            this.lblShirtNumber.Content = player.ShirtNumber;
            if (isHome)
                this.playerCircle.Fill = new SolidColorBrush(Colors.DarkBlue);
        }

        private void PlayerSelected(object sender, MouseButtonEventArgs e)
        {
            new PlayerWindow(_player).ShowDialog();
        }
    }
}
