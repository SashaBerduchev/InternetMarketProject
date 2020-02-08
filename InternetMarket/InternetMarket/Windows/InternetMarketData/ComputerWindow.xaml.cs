using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace InternetMarket
{
    /// <summary>
    /// Логика взаимодействия для ComputerWindow.xaml
    /// </summary>
    public partial class ComputerWindow : Window
    {
        InterMarketService marketService;
        public ComputerWindow()
        {
            InitializeComponent();
            marketService = new InterMarketService();
            Trace.WriteLine(this);
        }

        private void btnset_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < Convert.ToInt32(textpoin.Text); i++)
            {
                Thread threads = new Thread(CompSet);
                Trace.WriteLine(threads);
                threads.Start();
            }
            
            this.Close();
        }
        public void CompSet()
        {
            Dispatcher.Invoke(() =>
            {
                string firm = firmsettext.Text;
                string model = modelsettext.Text;
                string quantity = quantitysettext.Text;
                string cost = costsettext.Text;
                string proc = procsettext.Text;
                string ram = ramsettext.Text;
                string vram = vramsettext.Text;
                string graphics = graphicsettext.Text;

                for (int i = 0; i < Convert.ToInt32(textpoin.Text); i++)
                {
                    marketService.ComputerSet(firm, model, quantity, cost, proc, ram, vram, graphics, textpoin.Text);
                }
            });
        }
    }
}

