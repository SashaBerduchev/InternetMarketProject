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
    /// Логика взаимодействия для OblastData.xaml
    /// </summary>
    public partial class OblastData : Window
    {
        public OblastData()
        {
            InitializeComponent();
        }

        private void OblastAddbtn_Click(object sender, RoutedEventArgs e)
        {
            Oblast oblast = new Oblast();
            oblast.Show();
        }

        private void OnlastLoad_Click(object sender, RoutedEventArgs e)
        {
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            List<OblastDataSetSet> oblastDataSets;
            oblastDataSets = internetMarketDateEntities.OblastDataSetSet.ToList();
            oblastDataGrid.ItemsSource = oblastDataSets.Select(x => new { x.Name, x.City, x.Country });
        }
    }
}
