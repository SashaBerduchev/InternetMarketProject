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
    /// Логика взаимодействия для AddMailServerWindow.xaml
    /// </summary>
    public partial class AddMailServerWindow : Window
    {
        private InterMarketService interMarket;
        private string[] servers = new string[10];
        public AddMailServerWindow(InterMarketService interMarket)
        {
            this.interMarket = interMarket;
            InitializeComponent();
        }

        private void smtpset_Click(object sender, RoutedEventArgs e)
        {
            servers[0] = smtpstring.Text;
            interMarket.SetServer(servers);
        }
    }
}
