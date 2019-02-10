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

namespace InternetMarket.Windows.Spravochniki
{
    /// <summary>
    /// Логика взаимодействия для SkladAdd.xaml
    /// </summary>
    public partial class SkladAdd : Window
    {
        public SkladAdd()
        {
            InitializeComponent();

            List<OrganizationSet> organizations;
            List<OblastDataSet> oblasts;
            List<CityData> cities;
            List<StreetSet> streets;
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            organizations = internetMarketDateEntities.OrganizationSetSet.ToList();
            oblasts = internetMarketDateEntities.OblastDataSetSet.ToList();
            cities = internetMarketDateEntities.CityDataSet.ToList();
            streets = internetMarketDateEntities.StreetSetSet.ToList();
            organisationtext.ItemsSource = organizations.Select(x => new { x.Name });
            oblasttext.ItemsSource = oblasts.Select(x => new { x.Name, x.Country, x.City });
            citytext.ItemsSource = cities.Select(x => new { x.Name, x.CountryName });
            streettext.ItemsSource = streets.Select(x => new { x.NameStreen, x.City, x.Country });
        }

        private void SetBtn_Click(object sender, RoutedEventArgs e)
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            CkladSet ckladdata = new CkladSet
            {
                Name = nametext.Text,
                Type = typetext.Text,
                City = citytext.Text,
                Oblast = oblasttext.Text,
                Organisation = organisationtext.Text,
                Street = streettext.Text
            };
            internetMarketDateEntities.CkladSetSet.Add(ckladdata);
            internetMarketDateEntities.SaveChanges();

        }
    }
}
