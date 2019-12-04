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
using System.Windows.Shapes;

namespace InternetMarket
{
    /// <summary>
    /// Логика взаимодействия для LoginUserWindow.xaml
    /// </summary>
    public partial class LoginUserWindow : Window, IDisposable
    {
        private InternetMarketDateEntities internetMarketDateEntities;
        private InterMarketService interMarketService;
        public LoginUserWindow()
        {
            InitializeComponent();
            StartConnection();

            Trace.WriteLine(this);
            interMarketService = new InterMarketService();
            //Костыль, если нету юзеров
            interMarketService.SetUserIfApsent();
            //GetUser data

            try
            {
                if (internetMarketDateEntities != null) internetMarketDateEntities = null; //обнулить есл существует
                internetMarketDateEntities = new InternetMarketDateEntities();
                User.ItemsSource = internetMarketDateEntities.UserSet.Select(x => x.Name).ToList();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Нет подключентя к базе данных", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Trace.WriteLine(exp.ToString());
            }
        }

        private void StartConnection()
        {
            try
            {
                //string uriAddress = "net.tcp://192.168.1.104:7000/IContract";//4
                string uriAddress = "net.tcp://localhost:4000/IContract"; 
                Uri addres = new Uri(uriAddress);//5
                NetTcpBinding binding = new NetTcpBinding();//6
                binding.ListenBacklog = 2000;//7
                binding.MaxConnections = 2000;//8
                binding.TransferMode = TransferMode.Buffered;//9
                binding.MaxReceivedMessageSize = 104857600;//10
                Type type = typeof(IContract);//11
                ServiceHost serviceHost = new ServiceHost(typeof(InterMarketService));//12
                serviceHost.AddServiceEndpoint(type, binding, uriAddress);//13
                serviceHost.Open();//14
                Trace.WriteLine(serviceHost);
            }catch(Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                MessageBoxResult res = MessageBox.Show("Ошибка подключения к серверу, неверный ip, port, попробовать снова?", "Error", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (res == MessageBoxResult.Yes)
                {
                    new LoginUserWindow().Show();
                    this.Close();
                }
            }
        }

        private void BtlLogin_Click(object sender, RoutedEventArgs e)
        {
            internetMarketDateEntities = new InternetMarketDateEntities();
            try
            {
                List<string> pass = internetMarketDateEntities.UserSet.Where(x => x.Name.Contains(User.SelectedItem.ToString())).Select(p => p.Password).ToList();
                if (pass.Contains(Password.Password))
                {
                    UserSet user = new UserSet
                    {
                        Name = User.SelectedItem.ToString(),
                        Password = Password.Password
                    };
                    internetMarketDateEntities.UserSet.Add(user);
                    internetMarketDateEntities.SaveChanges();
                    new MainWindow(this).Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (NotSupportedException)
            {
                MessageBoxResult result = MessageBox.Show("Выберите пользователя", "Error", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    this.Close();
                }

            }
            catch (NullReferenceException)
            {
                MessageBoxResult result = MessageBox.Show("Ведите пароль", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBoxResult result = MessageBox.Show("Не удалось войти в систему", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    this.Close();
                }
            }
            Dispose();
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                internetMarketDateEntities = new InternetMarketDateEntities();
                List<string> pass = internetMarketDateEntities.UserSet.Where(x => x.Name.Contains(User.SelectedItem.ToString())).Select(p => p.Password).ToList();
                if (pass.Contains(Password.Password))
                {
                    UserSet user = new UserSet
                    {
                        Name = User.SelectedItem.ToString(),
                        Password = Password.Password
                    };
                    internetMarketDateEntities.UserSet.Add(user);
                    internetMarketDateEntities.SaveChanges();
                    new MainWindow(this).Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        public void StopServer()
        {
            interMarketService.Dispose();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dispose();
        }
        public void Dispose()
        {
            if (internetMarketDateEntities != null)
            {
                internetMarketDateEntities.Dispose();
                internetMarketDateEntities = null;
            }
        }
    }
}
