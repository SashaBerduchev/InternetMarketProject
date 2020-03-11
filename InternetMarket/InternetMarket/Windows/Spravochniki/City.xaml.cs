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
    /// Логика взаимодействия для City.xaml
    /// </summary>
    public partial class City : Window
    {
        public City()
        {
            InitializeComponent();

            List<CountrySet> countries;
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            countries = internetMarketDateEntities.CountrySet.ToList();
            citycombo.ItemsSource = countries.Select(x => new { x.NameCountry });
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {

            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            var citydata = new CityDataSet
            {
                Name = cityname.Text,
                CountryName = citycombo.SelectedItem.ToString()
            };
            internetMarketDateEntities.CityDataSet.Add(citydata);
            internetMarketDateEntities.SaveChanges();
        }
    }
}
