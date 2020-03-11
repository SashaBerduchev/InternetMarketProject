using System.Collections.Generic;
using System.Linq;
using System.Windows;

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

            List<OrganizationSetSet> organizations;
            List<OblastDataSetSet> oblasts;
            List<CityDataSet> cities;
            List<StreetSetSet> streets;
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
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
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            CkladSetSet ckladdata = new CkladSetSet
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
