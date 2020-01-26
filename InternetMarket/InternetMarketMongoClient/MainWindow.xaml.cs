using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InternetMarketMongoClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IContract contract;
        private ChannelFactory<IContract> _factory;
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
            Trace.WriteLine(this);
            
            Trace.WriteLine(this);
            try
            {
                string uriAddress = "net.tcp://localhost:5000/IContract";
                Uri uri = new Uri(uriAddress);

                NetTcpBinding netTcpBinding = new NetTcpBinding();
                EndpointAddress endpoint = new EndpointAddress(uriAddress);
                _factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
                contract = _factory.CreateChannel();

            }
            catch(Exception exp)
            {
                Trace.WriteLine(exp.StackTrace);
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (combobox.SelectedItem.ToString() == "Phones")
            {
                contract.GetPhones();
                listbox.ItemsSource = contract.GetList();
            }
        }
        

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
