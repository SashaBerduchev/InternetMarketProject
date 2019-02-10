using System;
using System.Threading;
using System.Windows;

namespace InternetMarket
{
    /// <summary>
    /// Логика взаимодействия для ComputerWindow.xaml
    /// </summary>
    public partial class ComputerWindow : Window
    {
        public ComputerWindow()
        {
            InitializeComponent();
        }

        private void btnset_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < Convert.ToInt32(textpoin.Text); i++)
            {
                Thread threads = new Thread(CompSet);
                threads.Start();
            }

          

            ComputerWindow computerWindow = new ComputerWindow();
            computerWindow.Close();
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
                InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();

                for (int i = 0; i < Convert.ToInt32(textpoin.Text); i++)
                {
                    var comp = new ComputersSet
                    {
                        Cost = cost,
                        Firm = firm,
                        Model = model,
                        Processor = proc,
                        Graphics = graphics,
                        Quantity = quantity,
                        RAM = ram,
                        VRAM = vram
                    };
                    internetMarketDateEntities.ComputersSet.Add(comp);
                    internetMarketDateEntities.SaveChanges();
                }
            });
        }
    }
}

