using System;
using System.Net;
using System.ServiceModel;
using System.Threading;
using System.Windows;

namespace InternetMarketClient.Windows.ClientData
{
    /// <summary>
    /// Логика взаимодействия для GraphicsCard.xaml
    /// </summary>
    public partial class GraphicsCard : Window
    {
        IContract contract;
        public GraphicsCard()
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
            try
            {
                ServicePointManager.DefaultConnectionLimit = 999999999;
                for (int i = 0; i < Convert.ToInt32(pointtext.Text); i++)
                {
                    Thread thread = new Thread(Set);
                    thread.Start();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Set()
        {
            contract.GraphicsCardSet(namegpu.Text, cores.Text, gpucores.Text, herts.Text, vram.Text, voltage.Text, Convert.ToInt32(pointtext.Text));
        }
    }
}
