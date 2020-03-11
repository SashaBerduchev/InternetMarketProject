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
    /// Логика взаимодействия для LoadDocument.xaml
    /// </summary>
    public partial class LoadDocument : Window
    {
        public LoadDocument()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenDocument openDocument = new OpenDocument();
            openDocument.Show();
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            List<DogovorSet> dogovors;
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            dogovors = internetMarketDateEntities.DogovorSet.ToList();
            datagrid.ItemsSource = dogovors.Select(x => new { x.Name });
        }
    }
}
