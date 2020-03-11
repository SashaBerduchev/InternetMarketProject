using System.Windows;

namespace InternetMarket
{
    /// <summary>
    /// Логика взаимодействия для Country.xaml
    /// </summary>
    public partial class Country : Window
    {
        public Country()
        {
            InitializeComponent();
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            string country = CountryName.Text;

            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            var countrydata = new CountrySet
            {
                NameCountry = country
            };
            internetMarketDateEntities.CountrySet.Add(countrydata);
            internetMarketDateEntities.SaveChanges();
        }
    }
}
