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

            List<Country> countries;
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            countries = internetMarketDateEntities.CountrySet.ToList();
            citycombo.ItemsSource = countries.Select(x => new { x.NameCountry });
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            var citydata = new CityData
            {
                Name = cityname.Text,
                CountryName = citycombo.SelectedItem.ToString()
            };
            internetMarketDateEntities.CityDataSet.Add(citydata);
            internetMarketDateEntities.SaveChanges();
        }
    }
}
