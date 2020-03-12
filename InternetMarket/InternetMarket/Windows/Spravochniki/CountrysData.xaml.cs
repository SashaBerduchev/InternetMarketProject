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
    /// Логика взаимодействия для CountrysData.xaml
    /// </summary>
    public partial class CountrysData : Window
    {
        public CountrysData()
        {
            InitializeComponent();
        }

        private void ContryAddbtn_Click(object sender, RoutedEventArgs e)
        {
            Country country = new Country();
            country.Show();
        }

        private void ContryLoad_Click(object sender, RoutedEventArgs e)
        {
            List<CountrySet> countries;
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            countries = internetMarketDateEntities.CountrySet.ToList();
            countryDataGrid.ItemsSource = countries.Select(x => new { x.NameCountry });
            
        }
    }
}
