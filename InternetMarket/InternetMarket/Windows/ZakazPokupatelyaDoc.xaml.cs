using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для ZakazPokupatelyaDoc.xaml
    /// </summary>
    public partial class ZakazPokupatelyaDoc : Window
    {
        public ZakazPokupatelyaDoc()
        {
            //try
            //{
                List<DirectorSet> directors;
                List<DogovorSet> dogovors;
                List<CkladSetSet> cklads;
                InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
                directors = internetMarketDateEntities.DirectorSet.ToList();
                contragent.ItemsSource = directors.Select(x => new { x.Name });
                dogovors = internetMarketDateEntities.DogovorSet.ToList();
                dogovor.ItemsSource = internetMarketDateEntities.DogovorSet.ToList();
                cklads = internetMarketDateEntities.CkladSetSet.ToList();
                sklad.ItemsSource = cklads.Select(x => new { x.Name });
           // }
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.ToString(), "Exaption", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
          

            InitializeComponent();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(SelectData);
            thread.Start();
        }

        public void SelectData()
        {
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            List<PhonesSet> phones;
            phones = internetMarketDateEntities.PhonesSet.ToList();
            listbox.ItemsSource = phones.Select(x=> new { x.Firm, x.Model, x.Quantity, x.Processor, x.RAM, x.Cost, x.Battery});
        }
    }
}
