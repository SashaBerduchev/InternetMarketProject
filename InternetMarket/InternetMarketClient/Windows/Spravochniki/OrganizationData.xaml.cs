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

namespace InternetMarketClient.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrganizationData.xaml
    /// </summary>
    public partial class OrganizationData : Window
    {
        public OrganizationData()
        {
            InitializeComponent();
        }

        private void OrganisationAddbtn_Click(object sender, RoutedEventArgs e)
        {
            OrganizationAdd organizationAdd = new OrganizationAdd();
            organizationAdd.Show();
        }
    }
}
