using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        private void BtlLogin_Click(object sender, RoutedEventArgs e)
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            UserSet user = new UserSet
            {
                Name = Name.Text,
                Password = Password.Password
            };
            internetMarketDateEntities.UserSet.Add(user);
            internetMarketDateEntities.SaveChanges();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
