using InternetMarket.Windows;
using InternetMarket.Windows.Administration;
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
            try//1
            {


                Dispatcher.Invoke(() =>//2
                {
                    InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();//3
                    graphics = internetMarketDateEntities.GraphicsCardSet.ToList();//4
                    DataGrid.ItemsSource = graphics.Select(x => new { x.Name, x.GraphicsCore, x.Herts, x.Cores, x.VRAM, x.Voltage });//

                });//5
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);//6
            }
        }


        public void GetLaptop()
        {
            try//1
            {

                Dispatcher.Invoke(() =>//2
                {
                    List<Laptops> laptops;//3
                    InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();//4
                    laptops = internetMarketDateEntities.LaptopsSet.ToList();//5
                    DataGrid.ItemsSource = laptops.Select(x => new { x.Name, x.Model, x.Procc, x.RAM, x.VRAM, x.GPU, x.SCREEN, x.Resolution, x.Battery });//6
                });
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);//7
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
            if (combobox.SelectedItem.ToString() == "Phones")//1
            {
                using (FileStream fileStream = new FileStream("filetext.txt", FileMode.Append))//2
                {
                    for (int i = 0; i < phones.Count; i++)//3
                    {

                        byte[] array = System.Text.Encoding.Default.GetBytes(phones[i].ToString());//1

                        fileStream.Write(array, 0, array.Length);//2
                    }

                }
                MessageBox.Show("Сохранено", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(combobox.SelectedItem.ToString() == "Computers")//1
            {
                using (FileStream fileStream = new FileStream("filetext.txt", FileMode.Append))//2
                {
                    for (int i = 0; i < computers.Count; i++)//3
                    {

                        byte[] array = System.Text.Encoding.Default.GetBytes(computers[i].ToString());//4

                        fileStream.Write(array, 0, array.Length);//5
                    }

                }
                MessageBox.Show("Сохранено", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);//6
            }
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileStream file = new FileStream("Information.txt", FileMode.Append); //1
                string savestr; //2
                savestr = DataGrid.SelectedItem.ToString();//3
                for (int i = 0; i < savestr.Length; i++)//4
                {
                    byte[] array = Encoding.Default.GetBytes(savestr.ToString());//1
                    file.Write(array, 0, array.Length);//2
                }
                file.Close();//5
                MessageBox.Show("Готово", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);//6
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);//7
            }
        }

        public void Dispose()
        {
            phones.Clear();//1
            graphics.Clear();//2
            computers.Clear();//3
            phones = null;//4
            graphics = null;//5
            computers = null;//6
        }

        private void MenuItem_ClickAdministration(object sender, RoutedEventArgs e)
        {
            AdministrationWindow administrationWindow = new AdministrationWindow();
            administrationWindow.Show();
        }
    }
}
