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
using System.Windows.Shapes;

namespace SoccerScore_WPF_edition
{
    /// <summary>
    /// Interaction logic for NationalTeamWindow.xaml
    /// </summary>
    public partial class NationalTeamWindow : Window
    {
        private readonly DataManager _dataManager;
        public NationalTeamWindow()
        {
            InitializeComponent();
        }
    }
}
