using InternetMarket;
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
        private InternetMarketDateEntities internetMarketDateEntities;
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
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Trace.WriteLine(this);
                
        }

       

        private void BtlLogin_Click(object sender, RoutedEventArgs e)
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
                new MainWindow().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                    new MainWindow().Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                Dispose();
            }
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
