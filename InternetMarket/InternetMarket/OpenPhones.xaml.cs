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
    /// Логика взаимодействия для OpenPhones.xaml
    /// </summary>
    public partial class OpenPhones : Window
    {
        public OpenPhones()
        {
            InitializeComponent();
        }

        private void btnset_Click(object sender, RoutedEventArgs e)
        {
            string firm = firmsettext.Text;
            string model = modelsettext.Text;
            string quantity = quantitysettext.Text;
            string cost = costsettext.Text;
            string proc = procsettext.Text;
            string ram = ramsettext.Text;
            string battery = batterysettext.Text;

            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();

            var phonedat = new PhonesSet
            {
                Battery = battery,
                Cost = cost,
                Firm = firm,
                Model = model,
                Processor = proc,
                Quantity = quantity,
                RAM = ram
            };
            internetMarketDateEntities.PhonesSet.Add(phonedat);
            internetMarketDateEntities.SaveChanges();

            OpenPhones openPhones = new OpenPhones();
            openPhones.Close();
        }

    }
}

