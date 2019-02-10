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

namespace InternetMarket.Windows.Documents
{
    /// <summary>
    /// Логика взаимодействия для ZakazPokupatyaData.xaml
    /// </summary>
    public partial class ZakazPokupatyaData : Window
    {
        public ZakazPokupatyaData()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            ZakazPokupatelyaDoc zakazPokupatelyaDoc = new ZakazPokupatelyaDoc();
            zakazPokupatelyaDoc.Show();
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
