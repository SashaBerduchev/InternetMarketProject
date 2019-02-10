using InternetMarketClient.Windows;
using InternetMarketClient.Windows.ClientData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace InternetMarketClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IContract contract;
        public MainWindow()
        {
            
            InitializeComponent();

            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();

            combobox.Items.Add("Phones");
            combobox.Items.Add("Tivis");
            combobox.Items.Add("Computers");
            combobox.Items.Add("Tablets");
            combobox.Items.Add("CPU");
            combobox.Items.Add("Graphics");
            combobox.Items.Add("Laptop");
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenPhones openPhones = new OpenPhones();
            openPhones.Show();
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (combobox.SelectedItem.ToString() == "Phones")
                {
                    ServicePointManager.DefaultConnectionLimit = 999999999;
                    listbox.ItemsSource = contract.LoadPhones();
                }
                else if (combobox.SelectedItem.ToString() == "Computers")
                {
                    ServicePointManager.DefaultConnectionLimit = 999999999;
                    listbox.ItemsSource = contract.LoadComputers();
                }
                else if (combobox.SelectedItem.ToString() == "CPU")
                {
                    ServicePointManager.DefaultConnectionLimit = 999999999;
                    listbox.ItemsSource = contract.LoadCPU();
                }
                else if (combobox.SelectedItem.ToString() == "Graphics")
                {
                    ServicePointManager.DefaultConnectionLimit = 999999999;
                    listbox.ItemsSource = contract.LoadGPU();
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void OpenBtnTivi_Click(object sender, RoutedEventArgs e)
        {
            openTivis openTivis = new openTivis();
            openTivis.Show();
        }

        private void OpenBtnComputers_Click(object sender, RoutedEventArgs e)
        {
            OpenComputers openComputers = new OpenComputers();
            openComputers.Show();
        }

        private void OpenBtnTablets_Click(object sender, RoutedEventArgs e)
        {
            OpenTablets openTablets = new OpenTablets();
            openTablets.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OrganizationData organizationData = new OrganizationData();
            organizationData.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            CountrysData countrysData = new CountrysData();
            countrysData.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            CityData cityData = new CityData();
            cityData.Show();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            OblastData oblastData = new OblastData();
            oblastData.Show();

        }

        private void OpenBtnCPU_Click(object sender, RoutedEventArgs e)
        {
            OpenCPU openCPU = new OpenCPU();
            openCPU.Show();
        }

        private void OpenBtnGraphics_Click(object sender, RoutedEventArgs e)
        {
            GraphicsCard graphicsCard = new GraphicsCard();
            graphicsCard.Show();
        }

        private void OpenBtnlaptop_Click(object sender, RoutedEventArgs e)
        {
            Laptop laptop = new Laptop();
            laptop.Show();
        }

        private void BnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileStream file = new FileStream("Information.txt", FileMode.Append);
                string savestr;
                savestr = listbox.SelectedItem.ToString();
                for (int i = 0; i < savestr.Length; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(savestr.ToString());
                    file.Write(array, 0, array.Length);
                }
                file.Close();
                MessageBox.Show("Готово", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
