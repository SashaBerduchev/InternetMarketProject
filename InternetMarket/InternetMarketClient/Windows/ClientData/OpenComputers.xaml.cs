using System;
using System.Collections.Generic;
using System.Linq;
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

namespace InternetMarketClient.Windows
{
    /// <summary>
    /// Логика взаимодействия для OpenComputers.xaml
    /// </summary>
    public partial class OpenComputers : Window
    {
        IContract contract;
        public OpenComputers()
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
                System.Net.ServicePointManager.DefaultConnectionLimit = 999999999;
                for (int i = 0; i < Convert.ToInt32(textpoin.Text); i++)
                {
                    Thread thread = new Thread(Set);
                    thread.Start();
                }
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Set()
        {
            try
            {

                Dispatcher.Invoke(() =>
                {
                    contract.ComputerSet(FirmText.Text, ModelText.Text, Quantity.Text, Cost.Text, Processor.Text, RAM.Text, VRAM.Text, Graphics.Text, textpoin.Text);
                });
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
