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

namespace InternetMarketClient.Windows.Administration
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindowClient.xaml
    /// </summary>
    public partial class AddUserWindowClient : Window
    {
        IContract contract;
        public AddUserWindowClient()
        {
            InitializeComponent();
        }

        private void TextUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contract.setUserLogin(User.Text, Password.Password);
                this.Close();

            }
            catch(Exception exce)
            {
                MessageBox.Show(exce.ToString(),"warning", MessageBoxButton.OK, MessageBoxIcon.Error);
            }
        }
    }
}
