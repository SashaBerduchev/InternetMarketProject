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
    /// Логика взаимодействия для OrganisationAdd.xaml
    /// </summary>
    public partial class OrganisationAdd : Window
    {
        public OrganisationAdd()
        {
            InitializeComponent();
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            OrganizationSet organization = new OrganizationSet
            {
                Name = orgname.Text
            };
            internetMarketDateEntities.OrganizationSetSet.Add(organization);
            internetMarketDateEntities.SaveChanges();
        }
    }
}
