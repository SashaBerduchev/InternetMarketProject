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
    /// Логика взаимодействия для ContragentData.xaml
    /// </summary>
    public partial class ContragentData : Window
    {
        public ContragentData()
        {
            InitializeComponent();
        }




        private void ContragentAddbtn_Click(object sender, RoutedEventArgs e)
        {
            Contragent contragent = new Contragent();
            contragent.Show();
        }

        private void ContragentLoad_Click(object sender, RoutedEventArgs e)
        {
            List<DirectorSet> directors;
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            directors = internetMarketDateEntities.DirectorSet.ToList();
            contragentDataGrid.ItemsSource = directors.Select(x => new { x.Name, x.Country, x.Oblast, x.City, x.Region });
        }

        
    }
}
