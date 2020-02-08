using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace InternetMarket.Windows.InternetMarketData
{
    /// <summary>
    /// Логика взаимодействия для BoilerWindow.xaml
    /// </summary>
    public partial class BoilerWindow : Window
    {
        private InternetMarketDateEntities internetMarketDateEntities;
        private InterMarketService interMarket;
        public BoilerWindow()
        {
            InitializeComponent();
            Trace.WriteLine(this);
            interMarket = new InterMarketService();
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            interMarket.SetBoiler(Name.Text, Model.Text, Volume.Text, Voltage.Text, Power.Text, Cost.Text);
        }
    }
}
