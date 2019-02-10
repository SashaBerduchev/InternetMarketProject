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

            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            var countrydata = new Country
            {
                NameCountry = country
            };
            internetMarketDateEntities.CountrySet.Add(countrydata);
            internetMarketDateEntities.SaveChanges();
        }
    }
}
