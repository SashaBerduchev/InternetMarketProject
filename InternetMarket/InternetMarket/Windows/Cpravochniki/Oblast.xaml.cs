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
    /// Логика взаимодействия для Oblast.xaml
    /// </summary>
    public partial class Oblast : Window
    {
        public Oblast()
        {
            InitializeComponent();
            List<Country> countries;
            List<CityData> cities;
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            countries = internetMarketDateEntities.CountrySet.ToList();
            cities = internetMarketDateEntities.CityDataSet.ToList();
            countrycombo.ItemsSource = countries.Select(x=> new { x.NameCountry});
            citycombo.ItemsSource = cities.Select(x=> new { x.Name});

        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities(); ;
            var oblastdata = new OblastDataSet
            {
                Name = oblastname.Text,
                Country = countrycombo.SelectedItem.ToString(),
                City = citycombo.SelectedItem.ToString()

            };
            internetMarketDateEntities.OblastDataSetSet.Add(oblastdata);
            internetMarketDateEntities.SaveChanges();
        }
    }
}
