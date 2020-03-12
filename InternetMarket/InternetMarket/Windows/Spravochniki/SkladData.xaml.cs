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
    /// Логика взаимодействия для SkladData.xaml
    /// </summary>
    public partial class SkladData : Window
    {
        public SkladData()
        {
            InitializeComponent();
        }

        private void SkladAddbtn_Click(object sender, RoutedEventArgs e)
        {
            SkladAdd skladAdd = new SkladAdd();
            skladAdd.Show();
        }

        private void SkladLoad_Click(object sender, RoutedEventArgs e)
        {
            List<CkladSetSet> cklads;
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            cklads = internetMarketDateEntities.CkladSetSet.ToList();
            skladDataGrid.ItemsSource = cklads.Select(x => new { x.Name, x.Type, x.Organisation, x.City, x.Oblast, x.Street });
        }
    }
}
