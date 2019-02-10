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
    /// Логика взаимодействия для Region.xaml
    /// </summary>
    public partial class Region : Window
    {
        public Region()
        {
            InitializeComponent();
            List<Country> countries;
            List<CityData> cities;
            List<OblastDataSet> oblasts;

            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            countries = internetMarketDateEntities.CountrySet.ToList();
            cities = internetMarketDateEntities.CityDataSet.ToList();
            oblasts = internetMarketDateEntities.OblastDataSetSet.ToList();
            countrycombo.ItemsSource = countries.Select(x => new { x.NameCountry });
            citycombo.ItemsSource = cities.Select(x => new { x.Name });
            oblastname.ItemsSource = oblasts.Select(x => new { x.Name, x.Country, x.City });
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            var regdata = new RegionData
            {
                Name = regname.Text,
                Country = countrycombo.SelectedItem.ToString(),
                City = citycombo.SelectedItem.ToString(),
                Oblast = oblastname.SelectedItem.ToString()
            };
            internetMarketDateEntities.RegionDataSet.Add(regdata);
            internetMarketDateEntities.SaveChanges();
        }
    }
}
