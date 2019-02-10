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

namespace InternetMarket.Windows
{
    /// <summary>
    /// Логика взаимодействия для StreetDat.xaml
    /// </summary>
    public partial class StreetDat : Window
    {
        public StreetDat()
        {
            InitializeComponent();
        }

        private void StreetAddbtn_Click(object sender, RoutedEventArgs e)
        {
            Streets streets = new Streets();
            streets.Show();
        }

        private void StreetLoad_Click(object sender, RoutedEventArgs e)
        {
            List<StreetSet> streets;
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            streets = internetMarketDateEntities.StreetSetSet.ToList();
            streetDataGrid.ItemsSource = streets.Select(x => new { x.Country, x.City, x.Region, x.NameStreen });
        }
    }
}
