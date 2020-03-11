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

namespace InternetMarket.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegionDat.xaml
    /// </summary>
    public partial class RegionDat : Window
    {
        public RegionDat()
        {
            InitializeComponent();
        }

        private void RegionAddbtn_Click(object sender, RoutedEventArgs e)
        {
            Region region = new Region();
            region.Show();
        }

        private void RegionLoad_Click(object sender, RoutedEventArgs e)
        {
            List<RegionDataSet> regions;
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            regions = internetMarketDateEntities.RegionDataSet.ToList();
            regoinDataGrid.ItemsSource = regions.Select(x => new { x.Name, x.Country, x.City, x.Oblast });

        }
    }
}
