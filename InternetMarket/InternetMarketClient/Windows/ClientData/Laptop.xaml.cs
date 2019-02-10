using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
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

namespace InternetMarketClient.Windows.ClientData
{
    /// <summary>
    /// Логика взаимодействия для Laptop.xaml
    /// </summary>
    public partial class Laptop : Window
    {
        IContract contract;
        public Laptop()
        {
            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();
            InitializeComponent();
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            ServicePointManager.DefaultConnectionLimit = 999999999;
            for(int i=0; i<Convert.ToInt32(pointertext.Text); i++)
            {
                Thread thread = new Thread(Set);
                thread.Start();
            }
        }

        public void Set()
        {
            Dispatcher.Invoke(() =>
            {
                contract.LaptopSet(namelaptom.Text, modellaptom.Text, procclaptom.Text, ramlaptom.Text, vramlaptom.Text, gpulaptom.Text, screenlaptom.Text, resolutionlaptom.Text, baterrylaptom.Text, Convert.ToInt32(pointertext.Text));
            });
        }
    }
}
