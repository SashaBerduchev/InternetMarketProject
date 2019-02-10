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
        public OpenTablets()
        {
            InitializeComponent();
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
                InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
                for (int i = 0; i < Convert.ToInt32(pointtext.Text); i++)
                {
                    
                    TabletSet tabletSet = new TabletSet
                    {
                        Name = tabletname.Text,
                        Model = tabletmodel.Text,
                        Processor = tabletproc.Text,
                        RAM = tabletRAM.Text,
                        GPU = tabletGPU.Text,
                        Battery = tabletbattery.Text,
                        Resolution = tabletreolution.Text
                    };
                    internetMarketDateEntities.TabletSetSet.Add(tabletSet);
                    internetMarketDateEntities.SaveChanges();
                }
            });
        }
    }
}
