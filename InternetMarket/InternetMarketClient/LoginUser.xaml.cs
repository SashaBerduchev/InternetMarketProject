using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Windows;

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
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Trace.WriteLine(this);
                
        }

        private void BtlLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contract.setLogin(User.SelectedItem.ToString(), Password.Password);
                MainWindow main = new MainWindow();
                main.Show();
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
         }

        
    }
}
