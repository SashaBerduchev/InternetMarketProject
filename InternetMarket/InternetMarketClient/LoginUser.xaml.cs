using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;

namespace InternetMarketClient
{
    /// <summary>
    /// Логика взаимодействия для LoginUser.xaml
    /// </summary>
    public partial class LoginUser : Window, IDisposable
    {

        //List<UsersSet> usery;
        protected IContract contract;
        ChannelFactory<IContract> _factory;
        public LoginUser()
        {
            InitializeComponent();
            StartConnetion();
            Trace.WriteLine(this);
        }

        private void StartConnetion()
        {
            //string uriAddress ("net.tcp://192.168.1.104:7000/IContract");
            string uriAddress = "net.tcp://localhost:4000/IContract";
            Uri uri = new Uri(uriAddress);

            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uriAddress);
            _factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            Trace.WriteLine(this);
            contract = _factory.CreateChannel();
            try
            {
                User.ItemsSource = contract.GetUsers();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.StackTrace);
                MessageBox.Show("Ошибка подкчения к севреру", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtlLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (contract.SetUserLogin(User.SelectedItem.ToString(), Password.Password))
                {
                    new MainWindow(contract).Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } catch (NullReferenceException)
            {
                MessageBoxResult result = MessageBox.Show("Выберите пользователя", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    new LoginUser().Show();
                    this.Close();
                }
                else if (result == MessageBoxResult.No)
                {
                    this.Close();
                }
            } catch (CommunicationException)
            {

                MessageBoxResult result = MessageBox.Show("Ошибка подключения к серверу", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (result == MessageBoxResult.Yes)
                {
                    new LoginUser().Show();
                    this.Close();
                }
                else if (result == MessageBoxResult.No)
                {
                    this.Close();
                }
            }
        }

            
        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    if (contract.SetUserLogin(User.SelectedItem.ToString(), Password.Password))
                    {
                        new MainWindow(contract).Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBoxResult result = MessageBox.Show("Выберите пользователя", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        new LoginUser().Show();
                        this.Close();
                    }
                    else if (result == MessageBoxResult.No)
                    {
                        this.Close();
                    }
                }catch (CommunicationException)
                {
                    MessageBoxResult result = MessageBox.Show("Ошибка подключения к серверу", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Error);
                    if (result == MessageBoxResult.Yes)
                    {
                        new LoginUser().Show();
                        this.Close();
                    }
                    else if (result == MessageBoxResult.No)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dispose();
        }
        public void Dispose()
        {
            if (_factory != null)
                try
                {
                    _factory.Close();
                }catch(Exception exp)
                {
                    Trace.WriteLine(exp.ToString());
                    MessageBoxResult result = MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.YesNo, MessageBoxImage.Error);
                    if (result == MessageBoxResult.Yes)
                    {
                        new LoginUser().Show();
                    }
                }
        }
    }
}
