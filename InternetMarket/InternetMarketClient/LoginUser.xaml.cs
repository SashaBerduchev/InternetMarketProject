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
        private ChannelFactory<IContract> _factory;
        private static string pass = "";

        public LoginUser()
        {
            InitializeComponent();
            StartConnetion();
            Trace.WriteLine(this);
        }
        
        private void StartConnetion()
        {
            Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            contract = factory.CreateChannel();
            try
            {
                User.ItemsSource = contract.GetUsers();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.StackTrace);
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                new LoginUser().Show();
            }
        }

        private void BtlLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (contract.CheckUser(User.SelectedItem.ToString(), Password.Password))
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
                    if (contract.CheckUser(User.SelectedItem.ToString(), Password.Password))
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
                    //_factory.Close();
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
        public static string PasswordText
        {
            get
            {
                return pass;
            }
        }
        private void Password_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            pass = Password.Password;
            
        }
    }
}
