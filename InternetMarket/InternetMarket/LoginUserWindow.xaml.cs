using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;

namespace InternetMarket
{
    /// <summary>
    /// Логика взаимодействия для LoginUserWindow.xaml
    /// </summary>
    public partial class LoginUserWindow : Window
    {
        private InterMarketService interMarketService;
        private static string pass = "";
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
                User.ItemsSource = interMarketService.GetUsers();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Нет подключентя к базе данных", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Trace.WriteLine(exp.StackTrace);
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
                Trace.WriteLine(exp.StackTrace);
                MessageBoxResult res = MessageBox.Show("Ошибка подключения к серверу, неверный ip, port, попробовать снова?", "Error", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (res == MessageBoxResult.Yes)
                {
                    new LoginUserWindow().Show();
                    this.Close();
                }
            }
        }


        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                List<string> Users = interMarketService.GetUsers();
                if (interMarketService.CheckUser(User.SelectedItem.ToString(), LoginUserWindow.PasswordText))
                {
                    new MainWindow(interMarketService).Show();
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
            //Dispose();
        }

        public static string PasswordText
        {
            get
            {
                return pass;
            }
        }

        private void Password_KeyUp(object sender, KeyEventArgs e)
        {
            pass = Password.Password;
        }

        private void btlLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> pass = interMarketService.GetUsers();
                if (interMarketService.CheckUser(User.SelectedItem.ToString(), LoginUserWindow.PasswordText))
                {
                    new MainWindow(interMarketService).Show();
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
        }
    }
}
