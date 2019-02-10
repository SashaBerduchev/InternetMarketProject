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
    /// Логика взаимодействия для OpenCPU.xaml
    /// </summary>
    public partial class OpenCPU : Window
    {
        IContract contract;
        public OpenCPU()
        {
            InitializeComponent();

            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServicePointManager.DefaultConnectionLimit = 999999999;
                for(int y=0; y<Convert.ToInt32(pointtext.Text); y++)
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
            Dispatcher.Invoke(() =>
            {
                contract.CPUSet(nametext.Text, Architecturetext.Text, chastotatext.Text, corestext.Text, KESHL1text.Text, KESHL2text.Text, KESHL3text.Text, GPUtext.Text, RAMtext.Text, TDPtext.Text, Convert.ToInt32(pointtext.Text));
            });
        }
    }
}
