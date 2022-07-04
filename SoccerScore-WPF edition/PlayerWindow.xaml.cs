﻿using SoccerScoreData.Models;
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
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        private Player _player;
        public PlayerWindow(Player player)
        {
            _player = player;
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.lblPlayerName.Text = _player.Name;
            this.lblShirtNumber.Content = _player.ShirtNumber;
            if(_player.IconPath != null)
            {
                //TO DO: SET IMAGE SOURCE
            }
        }
    }
}
