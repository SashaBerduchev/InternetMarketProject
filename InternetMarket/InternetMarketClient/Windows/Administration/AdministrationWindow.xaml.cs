﻿using System;
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

namespace InternetMarketClient.Windows.Administration
{
    /// <summary>
    /// Логика взаимодействия для AdministrationWindow.xaml
    /// </summary>
    public partial class AdministrationWindow : Window
    {
        public AdministrationWindow()
        {
            InitializeComponent();
            //MenuItem_ClickAdministration();
        }

        private void AddUserClick(object sender, RoutedEventArgs e)
        {
            new AddUserWindowClient().Show();
        }
    }
}