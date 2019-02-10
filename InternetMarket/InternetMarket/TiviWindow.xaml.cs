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
    /// Логика взаимодействия для TiviWindow.xaml
    /// </summary>
    public partial class TiviWindow : Window
    {
        public TiviWindow()
        {
            InitializeComponent();
        }

        private void btnset_Click(object sender, RoutedEventArgs e)
        {
            string firm = firmtext.Text;
            string model = modeltext.Text;
            string quantity = quantitytext.Text;
            string cost = costtext.Text;

            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();

            var tividata = new TivisetSet
            {
                Cost = cost,
                Model = model,
                Firm = firm,
                Quantity = quantity
            };
            internetMarketDateEntities.TivisetSet.Add(tividata);
            internetMarketDateEntities.SaveChanges();
            TiviWindow tiviWindow = new TiviWindow();
            tiviWindow.Close();
        }
    }
}
