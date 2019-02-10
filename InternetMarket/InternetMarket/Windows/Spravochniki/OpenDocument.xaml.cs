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
    /// Логика взаимодействия для OpenDocument.xaml
    /// </summary>
    public partial class OpenDocument : Window
    {
        public OpenDocument()
        {
            InitializeComponent();
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            var dogdata = new Dogovor
            {
                Name = namedoc.Text
            };
            internetMarketDateEntities.DogovorSet.Add(dogdata);
            internetMarketDateEntities.SaveChanges();
        }
    }
}
