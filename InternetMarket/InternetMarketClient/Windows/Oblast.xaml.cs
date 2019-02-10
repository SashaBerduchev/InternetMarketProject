using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace InternetMarketClient.Windows
{
    /// <summary>
    /// Логика взаимодействия для Oblast.xaml
    /// </summary>
    public partial class Oblast : Window
    {
        IContract contract;
        public Oblast()
        {
            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();
            countrycombo.ItemsSource = contract.GetCountry();
            citycombo.ItemsSource = contract.GetCity();
            InitializeComponent();
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            contract.Oblast(oblastname.Text, countrycombo.SelectedItem.ToString(), citycombo.SelectedItem.ToString());
        }
    }
}
