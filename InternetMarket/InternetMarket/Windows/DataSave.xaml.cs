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
    /// Логика взаимодействия для DataSave.xaml
    /// </summary>
    public partial class DataSave : Window
    {
        public DataSave()
        {
            InitializeComponent();

            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();

            List<OrganizationSetSet> organizations;
            organizations = internetMarketDateEntities.OrganizationSetSet.ToList();
            organization.ItemsSource = organizations.Select(x => new { x.Name });
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            List<PhonesSet> phones;
            List<ComputersSet> computers;
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();

            phones = internetMarketDateEntities.PhonesSet.ToList();
            computers = internetMarketDateEntities.ComputersSet.ToList();

            PhoneData.ItemsSource = phones.Select(x => new { x.Firm, x.Model, x.Quantity, x.Cost, x.Processor, x.RAM, x.Battery });
            CompData.ItemsSource = computers.Select(x => new { x.Firm, x.Model, x.Quantity, x.Processor, x.RAM, x.VRAM, x.Graphics });

            tempphone.ItemsSource = phones.Select(x => new { x.Firm, x.Model, x.Quantity, x.Cost, x.Processor, x.RAM, x.Battery });
            
        }
    }
}
