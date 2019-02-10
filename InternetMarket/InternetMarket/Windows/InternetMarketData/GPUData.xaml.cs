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
    /// Логика взаимодействия для GPUData.xaml
    /// </summary>
    public partial class GPUData : Window
    {
        public GPUData()
        {
            InitializeComponent();
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(pointtext.Text); i++)
            {
                Thread thread = new Thread(SetGPUData);
                thread.Start();  
            }
        }

        public void SetGPUData()
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();

            for (int i = 0; i < Convert.ToInt32(pointtext.Text); i++)
            {
                 
                var gpudata = new GraphicsCard
                {
                    Name = namegpu.Text,
                    Cores = cores.Text,
                    GraphicsCore = gpucores.Text,
                    Herts = herts.Text,
                    VRAM = vram.Text,
                    Voltage = voltage.Text
                };
                internetMarketDateEntities.GraphicsCardSet.Add(gpudata);
                internetMarketDateEntities.SaveChanges();
            }
        }
    }
}
