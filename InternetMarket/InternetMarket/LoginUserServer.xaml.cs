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

namespace InternetMarket.Windows.LoginUser
{
    /// <summary>
    /// Логика взаимодействия для LoginUserServer.xaml
    /// </summary>
    public partial class LoginUserServer : Window
    {
        
        public LoginUserServer()
        {
            InitializeComponent();
            string uriAddress = "net.tcp://localhost:4000/IContract";
            //Uri addres = new Uri("net.tcp://localhost:4000/IContract");
            Uri addres = new Uri(uriAddress);
            NetTcpBinding binding = new NetTcpBinding();
            binding.ListenBacklog = 2000;
            binding.MaxConnections = 2000;
            binding.TransferMode = TransferMode.Buffered;
            binding.MaxReceivedMessageSize = 104857600;
            Type type = typeof(IContract);
            ServiceHost serviceHost = new ServiceHost(typeof(InterMarketService));
            serviceHost.AddServiceEndpoint(type, binding, uriAddress);
            serviceHost.Open();
            //Костыль, если нету юзеров
            try
            {
                InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
                List<UserSet> userSet = internetMarketDateEntities.UserSet.ToList();
                if(userSet.Count() < 1)
                {
                    UserSet user = new UserSet{
                        Name = "Admin", Password = ""


                  };
                    internetMarketDateEntities.UserSet.Add(user);
                    internetMarketDateEntities.SaveChanges();
                    User.ItemsSource = internetMarketDateEntities.UserSet.Select(x => x.Name).ToList();

                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Warning! Kuda vy edete", MessageBoxButton.OK);
            }

        }

        private void BtlLogin_Click(object sender, RoutedEventArgs e)
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            UserSet user = new UserSet
            {
                Name = User.SelectedItem.ToString(),
                Password = Password.Password
            };
            internetMarketDateEntities.UserSet.Add(user);
            internetMarketDateEntities.SaveChanges();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
