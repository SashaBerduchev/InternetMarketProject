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

namespace InternetMarket.Windows.Users
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindowServer.xaml
    /// </summary>
    public partial class AddUserWindowServer : Window
    {
        IContract contract;
        public AddUserWindowServer()
        {
            InitializeComponent();
        }

        private void TextUser_Click(object sender, RoutedEventArgs e)
        {
            contract.setUserLogin(User.Text, Password.Password);
            this.Close();
        }
    }
}
