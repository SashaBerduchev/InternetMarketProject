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
    /// Логика взаимодействия для Streets.xaml
    /// </summary>
    public partial class Streets : Window
    {
        public Streets()
        {
            InitializeComponent();

            List<Country> countries;
            List<CityData> cities;
            List<RegionData> regions;
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            countries = internetMarketDateEntities.CountrySet.ToList();
            cities = internetMarketDateEntities.CityDataSet.ToList();
            regions = internetMarketDateEntities.RegionDataSet.ToList();

            countrycombo.ItemsSource = countries.Select(x => new { x.NameCountry });
            citycombo.ItemsSource = cities.Select(x => new { x.Name });
            regname.ItemsSource = regions.Select(x => new { x.Name });
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();

            var streetdat = new StreetSet
            {
                NameStreen = streettext.Text,
                City = citycombo.SelectedItem.ToString(),
                Country = countrycombo.SelectedItem.ToString(),
                Region = regname.SelectedItem.ToString()

            };
            internetMarketDateEntities.StreetSetSet.Add(streetdat);
            internetMarketDateEntities.SaveChanges();
        }
    }
}
