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
    /// Логика взаимодействия для Contragent.xaml
    /// </summary>
    public partial class Contragent : Window
    {
        public Contragent()
        {
            InitializeComponent();
            List<Country> countries;
            List<CityData> cities;
            List<OblastDataSet> oblasts;
            List<RegionData> regions;
            List<StreetSet> streets;
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            countries = internetMarketDateEntities.CountrySet.ToList();
            cities = internetMarketDateEntities.CityDataSet.ToList();
            oblasts = internetMarketDateEntities.OblastDataSetSet.ToList();
            regions = internetMarketDateEntities.RegionDataSet.ToList();
            streets = internetMarketDateEntities.StreetSetSet.ToList();

            countrycombo.ItemsSource = countries.Select(x => new { x.Name });
            citycombo.ItemsSource = cities.Select(x => new { x.Name });
            oblastcombo.ItemsSource = oblasts.Select(x => new { x.Name });
            regioncombo.ItemsSource = regions.Select(x => new { x.Name });
            steetcombo.ItemsSource = streets.Select(x => new { x.NameStreen });
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();

            var contragents = new Director
            {
                Country = countrycombo.SelectedItem.ToString(),
                City = citycombo.ItemsSource.ToString(),
                Oblast = oblastcombo.SelectedItem.ToString(),
                Region = regioncombo.ItemsSource.ToString(),
                Name = contragentname.Text

            };

            internetMarketDateEntities.DirectorSet.Add(contragents);
            internetMarketDateEntities.SaveChanges();
        }
    }
}
