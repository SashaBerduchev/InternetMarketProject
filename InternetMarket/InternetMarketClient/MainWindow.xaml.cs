using InternetMarket;
using InternetMarketClient.Windows;
using InternetMarketClient.Windows.Administration;
using InternetMarketClient.Windows.ClientData;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using CityData = InternetMarket.CityData;
using CountrysData = InternetMarket.CountrysData;
using GraphicsCard = InternetMarketClient.Windows.ClientData.GraphicsCard;
using OblastData = InternetMarket.Windows.OblastData;
using OpenComputers = InternetMarket.Windows.OpenComputers;
using OpenTablets = InternetMarket.Windows.OpenTablets;

namespace InternetMarketClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IContract contract;
        public MainWindow(IContract contract)
        {
            this.contract = contract;
            InitializeComponent();
            
            Trace.WriteLine(this);
            combobox.Items.Add("Phones");
            combobox.Items.Add("Tivis");
            combobox.Items.Add("Computers");
            combobox.Items.Add("Tablets");
            combobox.Items.Add("CPU");
            combobox.Items.Add("Graphics");
            combobox.Items.Add("Laptop");
            combobox.Items.Add("Boilers");
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
                    listbox.ItemsSource = contract.LoadPhones();
                }
                else if (combobox.SelectedItem.ToString() == "Computers")
                {
                    listbox.ItemsSource = contract.LoadComputers();
                }
                else if (combobox.SelectedItem.ToString() == "CPU")
                {
                    listbox.ItemsSource = contract.LoadCPU();
                }
                else if (combobox.SelectedItem.ToString() == "Graphics")
                {
                    listbox.ItemsSource = contract.LoadGPU();
                }
                else if (combobox.SelectedItem.ToString() == "Laptop")
                {
                    listbox.ItemsSource = contract.GetBoilersData();
                }
                else if (combobox.SelectedItem.ToString() == "Boilers")
                {
                    listbox.ItemsSource = contract.GetLaptop();
                }
            }
            catch(Exception exp)
            {
                Trace.WriteLine(exp.StackTrace);
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
            //cityData.Show();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            InternetMarket.Windows.OblastData oblastData = new OblastData();
            oblastData.Show();

        }

        private void OpenBtnCPU_Click(object sender, RoutedEventArgs e)
        {
            OpenCPU openCPU = new OpenCPU();
            openCPU.Show();
        }

        private void OpenBtnGraphics_Click(object sender, RoutedEventArgs e)
        {
            new GraphicsCard().Show();
        }

        private void OpenBtnlaptop_Click(object sender, RoutedEventArgs e)
        {
            InternetMarket.Windows.Laptop laptop = new InternetMarket.Windows.Laptop();
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

        private void MenuItem_ClickAdministration(object sender, RoutedEventArgs e)
        {
            AdministrationWindow administrationWindow = new AdministrationWindow();
            administrationWindow.Show();
        }

        private void DeleteBttn_Click(object sender, RoutedEventArgs e)
        {
            if (combobox.SelectedItem.ToString() == "Phones")
            {
                contract.RemovePhones(Convert.ToInt32(countStartDelete.Text),Convert.ToInt32(countFinishDelete.Text));
            }
        }

        private void OpenMail_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
