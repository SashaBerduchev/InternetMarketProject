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
    public partial class LoginUser : Window
    {
        
        //List<UsersSet> usery;
        IContract contract;
        public LoginUser()
        {
            InitializeComponent();
            Uri uri = new Uri("net.tcp://localhost:7000/IContract");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            
            contract = factory.CreateChannel();
            try
            {
                User.ItemsSource = contract.GetUsers();
            } catch(Exception e)
            {
                MessageBox.Show("Ошибка подкчения к севреру", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Trace.WriteLine(this);
                
        }

       

        private void BtlLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (contract.SetUserLogin(User.SelectedItem.ToString(), Password.Password))
                {
                    new MainWindow().Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }catch(NullReferenceException )
            {
                MessageBoxResult result = MessageBox.Show("Выберите пользователя", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if( result == MessageBoxResult.Yes)
                {
                    new LoginUser().Show();
                    this.Close();
                }
                else if (result == MessageBoxResult.No)
                {
                    this.Close();
                }
            }catch(CommunicationException)
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
                        new MainWindow().Show();
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
    }
}
