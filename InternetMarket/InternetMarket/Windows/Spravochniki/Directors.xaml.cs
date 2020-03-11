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

namespace InternetMarket
{
    /// <summary>
    /// Логика взаимодействия для Directors.xaml
    /// </summary>
    public partial class Directors : Window
    {
        public Directors()
        {
            InitializeComponent();

            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            List<CountrySet> countries;
            List<CityDataSet> cityDatas;

            countries = internetMarketDateEntities.CountrySet.ToList();
            Country.ItemsSource = countries.Select(x => new { x.NameCountry }).ToArray();

            cityDatas = internetMarketDateEntities.CityDataSet.ToList();
            City.ItemsSource = cityDatas.Select(x => new { x.Name, x.CountryName });

        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            string Name = NameDat.Text;
            

        }
    }
}
