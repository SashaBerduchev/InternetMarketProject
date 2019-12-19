using InternetMarket.Windows;
using InternetMarket.Windows.Administration;
using InternetMarket.Windows.Documents;
using InternetMarket.Windows.InternetMarketData;
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
    public partial class MainWindow : Window, IDisposable
    {
        private InternetMarketDateEntities internetMarketDateEntities;
        private List<GraphicsCard> graphics;
        private List<string> printers;
        private LoginUserWindow loginUserServer;
        private InterMarketService interMarketService;
        public MainWindow(LoginUserWindow login)
        {
            interMarketService = new InterMarketService();
            loginUserServer = login;
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
        }

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
            try
            {
                if (combobox.SelectedItem.ToString() == "Phones")
                {
                    Thread thread = new Thread(GetPhones);
                    thread.Start();
                    thread.IsBackground = true;

                }
                else if (combobox.SelectedItem.ToString() == "Tivis")
                {
                    Thread thread = new Thread(GetTivis);
                    thread.Start();
                    thread.IsBackground = true;
                }
                else if (combobox.SelectedItem.ToString() == "Computers")
                {
                    Thread thread = new Thread(GetComputers);
                    thread.Start();
                    thread.IsBackground = true;
                }

                else if (combobox.SelectedItem.ToString() == "Tablets")
                {
                    Thread thread = new Thread(GetTablets);
                    thread.Start();
                    thread.IsBackground = true;
                }

                else if (combobox.SelectedItem.ToString() == "CPU")
                {
                    Thread thread = new Thread(GetCPUInform);
                    thread.Start();
                    thread.IsBackground = true;
                }
                else if (combobox.SelectedItem.ToString() == "Graphics")
                {
                    Thread thread = new Thread(GetGraphicsCardInform);
                    thread.Start();
                    thread.IsBackground = true;
                }

                else if (combobox.SelectedItem.ToString() == "Laptop")
                {
                    Thread thread = new Thread(GetLaptop);
                    thread.Start();
                    thread.IsBackground = true;
                }
                else if (combobox.SelectedItem.ToString() == "Printers")
                {
                    Thread thread = new Thread(GetPrinters);
                    thread.Start();
                    thread.IsBackground = true;
                }
                else if (combobox.SelectedItem.ToString() == "Boilers")
                {
                    Thread thread = new Thread(GetBoilers);
                    thread.Start();
                    thread.IsBackground = true;
                }
            }
            catch (Exception exp)
            {
                if (exp is NullReferenceException)
                {
                    MessageBox.Show("Выбирите нужный параметр загрузки", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Trace.WriteLine(exp.ToString());
                }
                else
                {
                    MessageBox.Show(exp.ToString(), "NotIdentityError", MessageBoxButton.OK, MessageBoxImage.Error);
                    Trace.WriteLine(exp.ToString());
                }
            }

        }

        private void GetBoilers()
        {
            List<string> boilers = new List<string>();
            Dispatcher.Invoke(() =>
            {
                boilers = interMarketService.GetBoilersData();
                DataGrid.ItemsSource = boilers;
                GetCount();
            });
        }

        public void GetPhones()
        {
            Dispatcher.Invoke(() =>
                {
                    DataGrid.ItemsSource = interMarketService.LoadPhones();
                    GetCount();
                }
            );
        }

        public void GetTivis()
        {
            Dispatcher.Invoke(() =>
            {
                DataGrid.ItemsSource = interMarketService.LoadTivis();
                GetCount();
            });
        }
        public void GetTablets()
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    DataGrid.ItemsSource = interMarketService.LoadTablets();
                    GetCount();
                });
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void GetComputers()
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    DataGrid.ItemsSource = interMarketService.LoadComputers();
                    GetCount();
                });
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void GetCPUInform()
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    DataGrid.ItemsSource = interMarketService.LoadCPU();
                    GetCount();
                });
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void GetGraphicsCardInform()
        {
            try
            {
                Dispatcher.Invoke(() =>//2
                {
                    Dispose();
                    internetMarketDateEntities = new InternetMarketDateEntities();//3
                    graphics = internetMarketDateEntities.GraphicsCardSet.ToList();//4
                    DataGrid.ItemsSource = graphics.Select(x => new { x.Name, x.GraphicsCore, x.Herts, x.Cores, x.VRAM, x.Voltage });//
                    GetCount();
                });//5
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
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
                    GetCount();
                });
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);//7
            }
        }

        private void GetPrinters()
        {
            Dispatcher.Invoke(() =>
            {
                printers = new List<string>();
                internetMarketDateEntities = new InternetMarketDateEntities();
                printers = internetMarketDateEntities.PrintersSet.Select(x => x.Name + "" + x.Speed + "" + x.Colors + "" + x.Cost).ToList();
                DataGrid.ItemsSource = printers;
                GetCount();
            });
        }

        private void GetCount()
        {
            countElem.Text = Convert.ToString(DataGrid.Items.Count);
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
            AddCpuWindow cpu = new AddCpuWindow();
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
            try
            {
                if (combobox.SelectedItem.ToString() == "Phones")//1
                {
                    using (FileStream fileStream = new FileStream("filetext.txt", FileMode.Append))//2
                    {
                        List<PhonesSet> phones = interMarketService.GetPhonesCollection();
                        for (int i = 0; i < phones.Count; i++)//3
                        {

                            byte[] array = System.Text.Encoding.Default.GetBytes(phones[i].ToString());//1

                            fileStream.Write(array, 0, array.Length);//2
                        }

                    }
                    MessageBox.Show("Сохранено", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (combobox.SelectedItem.ToString() == "Computers")//1
                {
                    using (FileStream fileStream = new FileStream("filetext.txt", FileMode.Append))//2
                    {
                        List<ComputersSet> computers = interMarketService.GetCompCollection(); ;
                        for (int i = 0; i < computers.Count; i++)//3
                        {

                            byte[] array = System.Text.Encoding.Default.GetBytes(computers[i].ToString());//4

                            fileStream.Write(array, 0, array.Length);//5
                        }

                    }
                    MessageBox.Show("Сохранено", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);//6
                }
            }catch(NullReferenceException nullexp)
            {
                MessageBox.Show("Выберите данные для сохранения", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Trace.WriteLine(nullexp);
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Trace.WriteLine(exp);
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


        private void MenuItem_ClickAdministration(object sender, RoutedEventArgs e)
        {
            AdministrationWindow administrationWindow = new AdministrationWindow();
            administrationWindow.Show();
        }

        private void OpenBtnPrinter_Click(object sender, RoutedEventArgs e)
        {
            new PrinterWindow().Show();
        }

        private void OpenBtnBoiler_Click(object sender, RoutedEventArgs e)
        {
            new BoilerWindow().Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dispose();
        }

        

        private void Window_Closed(object sender, EventArgs e)
        {
            loginUserServer.StopServer();
        }

        public void Dispose()
        {
            if (graphics != null) graphics.Clear();//2
            if (printers != null) printers.Clear();
            graphics = null;//5
            printers = null;
            if (interMarketService != null) interMarketService.Dispose();
            interMarketService = null;
            if (internetMarketDateEntities != null) internetMarketDateEntities.Dispose();
            internetMarketDateEntities = null;

        }

        private void DeleteBttn_Click(object sender, RoutedEventArgs e)
        {

            Thread thread = new Thread(Delete);
            thread.IsBackground = true;
            thread.Start();
        }

        private void Delete()
        {
            Dispatcher.Invoke(() =>
            {
                try
                {
                    if (combobox.SelectedItem.ToString() == "Phones")
                    {
                        interMarketService.RemovePhones(Convert.ToInt32(countStartDelete.Text), Convert.ToInt32(countFinishDelete.Text));
                    }
                    else if (combobox.SelectedItem.ToString() == "Computers")
                    {
                        interMarketService.RemoveComputers(Convert.ToInt32(countStartDelete.Text), Convert.ToInt32(countFinishDelete.Text));
                    }
                    else if (combobox.SelectedItem.ToString() == "Tivis")
                    {
                        interMarketService.RemoveTivis(Convert.ToInt32(countStartDelete.Text), Convert.ToInt32(countFinishDelete.Text));
                    }
                    MessageBox.Show("Удалено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (NullReferenceException nullexp)
                {
                    Trace.WriteLine(nullexp.ToString());
                    MessageBox.Show("Выберите тип ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (FormatException formatexp)
                {
                    Trace.WriteLine(formatexp.ToString());
                    MessageBox.Show("Введите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (ArgumentOutOfRangeException argexp)
                {
                    Trace.WriteLine(argexp.ToString());
                    MessageBox.Show("Колличемство эллементов менше заданого диапазона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            });
        }
    }
}
