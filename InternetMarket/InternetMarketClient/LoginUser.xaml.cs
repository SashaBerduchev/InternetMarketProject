using System;
using System.Collections.Generic;
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
            Uri uri = new Uri("net.tcp://localhost:4000/InternetMarketService");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(uri);
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            
            contract = factory.CreateChannel();
            User.ItemsSource = contract.GetUsers();
                
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
