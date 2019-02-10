using System;
using System.ServiceModel;
using System.Threading;
using System.Windows;

namespace InternetMarketClient
{
    /// <summary>
    /// Логика взаимодействия для openTivis.xaml
    /// </summary>
    public partial class openTivis : Window
    {
        IContract contract;
        public openTivis()
        {
            InitializeComponent();


            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();
        }

        private void btnset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Net.ServicePointManager.DefaultConnectionLimit = 999999999;

                for (int i = 0; i < Convert.ToInt32(textpoin.Text); i++)
                {
                    Thread thread = new Thread(Set);
                    thread.Start();

                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            openTivis openTivis = new openTivis();
            openTivis.Close();

        }

        public void Set()
        {
            Dispatcher.Invoke(() =>
            {
                string firm = firmtext.Text;
                string model = modeltext.Text;
                string quantity = quantitytext.Text;
                string cost = costtext.Text;

                contract.TiviSet(firm, model, quantity, cost, textpoin.Text);
            });

        }
    }

}