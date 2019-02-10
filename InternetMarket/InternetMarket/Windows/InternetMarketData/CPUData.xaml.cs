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
    /// Логика взаимодействия для CPUData.xaml
    /// </summary>
    public partial class CPUData : Window
    {
        public CPUData()
        {
            InitializeComponent();
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(pointtext.Text); i++)
            {
                Thread thread = new Thread(SetCPUInform);
                thread.Start();
            }
        }

        public void SetCPUInform()
        {
            Dispatcher.Invoke(() =>
            {

            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();

                for (int i = 0; i < Convert.ToInt32(pointtext.Text); i++)
                {
                    CPU cpudata = new CPU
                    {
                        Name = nametext.Text,
                        Architecture = Architecturetext.Text,
                        Chastota = chastotatext.Text,
                        Cores = corestext.Text,
                        KESHL1 = KESHL1text.Text,
                        KESHL2 = KESHL2text.Text,
                        KESHL3 = KESHL3text.Text,
                        GPU = GPUtext.Text,
                        RAM = RAMtext.Text,
                        TDP = TDPtext.Text
                    };
                    internetMarketDateEntities.CPUSet.Add(cpudata);
                    internetMarketDateEntities.SaveChanges();
                }
            });
            
        }
    }
}
