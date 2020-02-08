using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace InternetMarket.Windows.InternetMarketData
{
    /// <summary>
    /// Логика взаимодействия для AddCpuWindow.xaml
    /// </summary>
    public partial class AddCpuWindow : Window, IDisposable
    {
        private InterMarketService interMarket;
        public AddCpuWindow()
        {
            interMarket = new InterMarketService();
            InitializeComponent();
            Trace.WriteLine(this);
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(pointtext.Text); i++)
            {
                Thread thread = new Thread(SetCPUInform);
                thread.IsBackground = true;
                thread.Start();
            }
        }

        private void SetCPUInform()
        {
            Dispatcher.Invoke(() =>
            {
                interMarket.CPUSet(nametext.Text, Architecturetext.Text, chastotatext.Text, corestext.Text, KESHL1text.Text, KESHL2text.Text, KESHL3text.Text, GPUtext.Text, RAMtext.Text, TDPtext.Text, Convert.ToInt32(pointtext.Text));
            });
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Dispose();
        }

        public void Dispose()
        {
            if (interMarket != null) interMarket.Dispose();
            interMarket = null;
        }
    }
}
