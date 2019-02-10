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

namespace InternetMarket.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrganisationData.xaml
    /// </summary>
    public partial class OrganisationData : Window
    {
        public OrganisationData()
        {
            InitializeComponent();
        }

        private void OrganisationAddbtn_Click(object sender, RoutedEventArgs e)
        {
            OrganisationAdd organisationAdd = new OrganisationAdd();
            organisationAdd.Show();
        }

        private void OrgaanisationLoad_Click(object sender, RoutedEventArgs e)
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            List<OrganizationSet> organizations;

            organizations = internetMarketDateEntities.OrganizationSetSet.ToList();
            organisationDataGrid.ItemsSource = organizations.Select(x => new { x.Name });
        }
    }
}
