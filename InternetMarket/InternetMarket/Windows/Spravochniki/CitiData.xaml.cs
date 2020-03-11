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
    /// Логика взаимодействия для CitiData.xaml
    /// </summary>
    public partial class CitiData : Window
    {
        public CitiData()
        {
            InitializeComponent();
        }

        private void CItyAddbtn_Click(object sender, RoutedEventArgs e)
        {
            City city = new City();
            city.Show();
        }

        private void CityLoad_Click(object sender, RoutedEventArgs e)
        {
            List<CityDataSet> cityDatas;
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            cityDatas = internetMarketDateEntities.CityDataSet.ToList();
            cityDataGrid.ItemsSource = cityDatas.Select(x => new { x.Name, x.CountryName});
        }

      
    }
}
