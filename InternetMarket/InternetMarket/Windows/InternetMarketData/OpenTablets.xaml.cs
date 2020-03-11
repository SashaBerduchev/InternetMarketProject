using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для OpenTablets.xaml
    /// </summary>
    public partial class OpenTablets : Window
    {
        private InterMarketService interMarket;
        public OpenTablets()
        {
            InitializeComponent();
            interMarket = new InterMarketService();
        }

        private void TabletSet_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < Convert.ToInt32(pointtext.Text); i++)
            {
                Thread thread = new Thread(SetTablet);
                thread.Start();
            }
        }

        public void SetTablet()
        {
            Dispatcher.Invoke(() =>
            {
                InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
                for (int i = 0; i < Convert.ToInt32(pointtext.Text); i++)
                {
                    interMarket.TabletsSet(tabletname.Text, tabletmodel.Text, tabletproc.Text, tabletRAM.Text, tabletGPU.Text, tabletreolution.Text, tabletbattery.Text, pointtext.Text);
                }
            });
        }
    }
}
