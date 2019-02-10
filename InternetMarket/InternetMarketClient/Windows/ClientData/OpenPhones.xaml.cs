using System;
using System.ServiceModel;
using System.Threading;
using System.Windows;

namespace InternetMarketClient
{
    /// <summary>
    /// Логика взаимодействия для OpenPhones.xaml
    /// </summary>
    public partial class OpenPhones : Window
    {
        IContract contract;
        public OpenPhones()
        {
            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();


            InitializeComponent();
        }

        private void btnset_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                System.Net.ServicePointManager.DefaultConnectionLimit = 999999999;

                for (int i = 0; i < Convert.ToInt32(textpoint.Text); i++)
                {
                    Thread thread = new Thread(Set);
                    thread.Start();
                }
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            OpenPhones openPhones = new OpenPhones();
            openPhones.Close();
        }

        public void Set()
        {
            Dispatcher.Invoke(() =>
            {
                string firm = firmsettext.Text;
                string model = modelsettext.Text;
                string quantity = quantitysettext.Text;
                string cost = costsettext.Text;
                string proc = procsettext.Text;
                string ram = ramsettext.Text;
                string battery = batterysettext.Text;
                contract.PhonesSet(firm, model, quantity, cost, proc, ram, battery, textpoint.Text);
            });
           
        }
    }
}
