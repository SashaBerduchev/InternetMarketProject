using InternetMarketMongoServer.SERVER;
using InternetMarketMongoServer.Windows;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarketMongoServer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InternetMarketMongoService mongoServer;
        public MainWindow()
        {
            InitializeComponent();
            combobox.Items.Add("Phones");
            combobox.Items.Add("Tivis");
            combobox.Items.Add("Computers");
            combobox.Items.Add("Tablets");
            combobox.Items.Add("CPU");
            combobox.Items.Add("Graphics");
            combobox.Items.Add("Laptop");
            combobox.Items.Add("Printers");
            combobox.Items.Add("Boilers");
            mongoServer = new InternetMarketMongoService();
            Trace.WriteLine(this);
            try
            {
                string uriAddress = "net.tcp://localhost:5000/IContract";
                Uri addres = new Uri(uriAddress);//5
                NetTcpBinding binding = new NetTcpBinding();//6
                binding.ListenBacklog = 2000;//7
                binding.MaxConnections = 2000;//8
                binding.TransferMode = TransferMode.Buffered;//9
                binding.MaxReceivedMessageSize = 104857600;//10
                Type type = typeof(IContract);//11
                ServiceHost serviceHost = new ServiceHost(typeof(InternetMarketMongoService));//12
                serviceHost.AddServiceEndpoint(type, binding, addres);//13
                serviceHost.Open();//14
                Trace.WriteLine(serviceHost);
            }catch(Exception exp)
            {
                Trace.WriteLine(exp.StackTrace);
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

        private void combobox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void GetCount()
        {
            countElem.Text = Convert.ToString(listbox.Items.Count);
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (combobox.SelectedItem.ToString() == "Phones")
            {
                Thread.Sleep(50);
                mongoServer.GetPhones();
                listbox.ItemsSource = mongoServer.GetListPhones();
                GetCount();
            }
            else if (combobox.SelectedItem.ToString() == "Computers")
            {
                Thread.Sleep(50);
                mongoServer.GetComputers();
                listbox.ItemsSource = mongoServer.GetCompList();
                GetCount();
            }
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddPhoneWindow(mongoServer).Show();
        }

        private void OpenBtnComputers_Click(object sender, RoutedEventArgs e)
        {
            new AddComputerWindow(mongoServer).Show();
        }
    }
}
