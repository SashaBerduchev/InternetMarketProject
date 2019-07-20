using InternetMarket.Windows;
using InternetMarket.Windows.Documents;
using InternetMarket.Windows.Spravochniki;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace InternetMarket
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , IDisposable
    {
        
        public MainWindow()
        {
            InitializeComponent();

            Uri addres = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            Type type = typeof(IContract);
            ServiceHost serviceHost = new ServiceHost(typeof(InterMarketService));
            serviceHost.AddServiceEndpoint(type, netTcpBinding, addres);
            serviceHost.Open();

            combobox.Items.Add("Phones");
            combobox.Items.Add("Tivis");
            combobox.Items.Add("Computers");
            combobox.Items.Add("Tablets");
            combobox.Items.Add("CPU");
            combobox.Items.Add("Graphics");
            combobox.Items.Add("Laptop");

            Trace.WriteLine(this);
        }

        List<PhonesSet> phones;
        List<ComputersSet> computers;
        List<GraphicsCard> graphics;
        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenPhones openPhones = new OpenPhones();
            openPhones.Show();
        }

        private void OpenBtnTivi_Click(object sender, RoutedEventArgs e)
        {
            TiviWindow tiviWindow = new TiviWindow();
            tiviWindow.Show();
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            if (combobox.SelectedItem.ToString() == "Phones")
            {
                Thread thread = new Thread(GetPhones);
                thread.Start();

            }
            else if (combobox.SelectedItem.ToString() == "Tivis")
            {
                Thread thread = new Thread(GetTivis);
                thread.Start();
            }
            else if (combobox.SelectedItem.ToString() == "Computers")
            {
                Thread thread = new Thread(GetComputers);
                thread.Start();
            }

            else if (combobox.SelectedItem.ToString() == "Tablets")
            {
                Thread thread = new Thread(GetTablets);
                thread.Start();
            }

            else if (combobox.SelectedItem.ToString() == "CPU")
            {
                Thread thread = new Thread(GetCPUInform);
                thread.Start();
            }
            else if (combobox.SelectedItem.ToString() == "Graphics")
            {
                Thread thread = new Thread(GetGraphicsCardInform);
                thread.Start();
            }

            else if (combobox.SelectedItem.ToString() == "Laptop")
            {
                Thread thread = new Thread(GetLaptop);
                thread.Start();
            }


        }

        public void GetPhones()
        {
            try
            {

                Dispatcher.Invoke(() =>
                {
                     InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
                     phones = internetMarketDateEntities.PhonesSet.ToList();
                     DataGrid.ItemsSource = phones.Select(x => new { x.Firm, x.Model, x.Quantity, x.Cost, x.Processor, x.RAM, x.Battery, x.Photo,  x.PDF
                     });
                   

                });
                phones.Clear();
            }catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public void GetTivis()
        {
            try
            {


                Dispatcher.Invoke(() =>
                {
                    List<TivisetSet> tivisets;
                    InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
                    tivisets = internetMarketDateEntities.TivisetSet.ToList();
                    DataGrid.ItemsSource = tivisets.Select(x => new { x.Firm, x.Model, x.Quantity, x.Cost });

                });
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void GetTablets()
        {
            try
            {


                Dispatcher.Invoke(() =>
                {
                    List<TabletSet> tablets;
                    InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
                    tablets = internetMarketDateEntities.TabletSetSet.ToList();
                    DataGrid.ItemsSource = tablets.Select(x => new { x.Name, x.Model, x.Processor, x.RAM, x.GPU, x.Battery, x.Resolution });

                });
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void GetComputers()
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    
                    InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
                    computers = internetMarketDateEntities.ComputersSet.ToList();
                    DataGrid.ItemsSource = computers.Select(x => new { x.Firm, x.Model, x.Quantity, x.Processor, x.RAM, x.VRAM, x.Graphics });

                });
                computers.Clear();
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public void GetCPUInform()
        {
            try
            {


                Dispatcher.Invoke(() =>
                {
                    List<CPU> cpus;
                    InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
                    cpus = internetMarketDateEntities.CPUSet.ToList();
                    DataGrid.ItemsSource = cpus.Select(x => new { x.Name, x.Architecture, x.Cores, x.Chastota, x.KESHL1, x.KESHL2, x.KESHL3, x.GPU, x.RAM, x.TDP });
                });
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void GetGraphicsCardInform()
        {
            try
            {


                Dispatcher.Invoke(() =>
                {
                    InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
                    graphics = internetMarketDateEntities.GraphicsCardSet.ToList();
                    DataGrid.ItemsSource = graphics.Select(x => new { x.Name, x.GraphicsCore, x.Herts, x.Cores, x.VRAM, x.Voltage });

                });
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void GetLaptop()
        {
            try
            {

                Dispatcher.Invoke(() =>
                {
                    List<Laptops> laptops;
                    InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
                    laptops = internetMarketDateEntities.LaptopsSet.ToList();
                    DataGrid.ItemsSource = laptops.Select(x => new { x.Name, x.Model, x.Procc, x.RAM, x.VRAM, x.GPU, x.SCREEN, x.Resolution, x.Battery });
                });
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        private void OpenBtnComputers_Click(object sender, RoutedEventArgs e)
        {
            ComputerWindow computerWindow = new ComputerWindow();
            computerWindow.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Directors directors = new Directors();
            directors.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            CountrysData countrysData = new CountrysData();
            countrysData.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            CitiData citiData = new CitiData();
            citiData.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            OblastData oblastData = new OblastData();
            oblastData.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            RegionDat regionDat = new RegionDat();
            regionDat.Show();
        }


        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            StreetDat streetDat = new StreetDat();
            streetDat.Show();
        }

        private void OpenBtnTablets_Click(object sender, RoutedEventArgs e)
        {
            OpenTablets openTablets = new OpenTablets();
            openTablets.Show();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            DataSave dataSave = new DataSave();
            dataSave.Show();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            ContragentData contragent = new ContragentData();
            contragent.Show();
        }

        private void OpenBtnCPU_Click(object sender, RoutedEventArgs e)
        {
            CPUData cpu = new CPUData();
            cpu.Show();
        }

        private void OpenBtnGraphics_Click(object sender, RoutedEventArgs e)
        {
            GPUData gpuData = new GPUData();
            gpuData.Show();
        }

        private void OpenBtnlaptop_Click(object sender, RoutedEventArgs e)
        {
            Laptop laptop = new Laptop();
            laptop.Show();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            LoadDocument loadDocument = new LoadDocument();
            loadDocument.Show();
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            ZakazPokupatyaData zakazPokupatyaData = new ZakazPokupatyaData();
            zakazPokupatyaData.Show();
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            OrganisationData organisationData = new OrganisationData();
            organisationData.Show();
           
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            SkladData skladData = new SkladData();
            skladData.Show();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            if (combobox.SelectedItem.ToString() == "Phones")
            {
                using (FileStream fileStream = new FileStream("filetext.txt", FileMode.Append))
                {
                    for (int i = 0; i < phones.Count; i++)
                    {

                        byte[] array = System.Text.Encoding.Default.GetBytes(phones[i].ToString());

                        fileStream.Write(array, 0, array.Length);
                    }

                }
                MessageBox.Show("Сохранено", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(combobox.SelectedItem.ToString() == "Computers")
            {
                using (FileStream fileStream = new FileStream("filetext.txt", FileMode.Append))
                {
                    for (int i = 0; i < computers.Count; i++)
                    {

                        byte[] array = System.Text.Encoding.Default.GetBytes(computers[i].ToString());

                        fileStream.Write(array, 0, array.Length);
                    }

                }
                MessageBox.Show("Сохранено", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileStream file = new FileStream("Information.txt", FileMode.Append);
                string savestr;
                savestr = DataGrid.SelectedItem.ToString();
                for (int i = 0; i < savestr.Length; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(savestr.ToString());
                    file.Write(array, 0, array.Length);
                }
                file.Close();
                MessageBox.Show("Готово", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Dispose()
        {
            phones.Clear();
            graphics.Clear();
            computers.Clear();
            phones = null;
            graphics = null;
            computers = null;
        }

     
    }
}
