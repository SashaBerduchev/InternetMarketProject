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
    /// Логика взаимодействия для OpenComputers.xaml
    /// </summary>
    public partial class OpenComputers : Window
    {
        public OpenComputers()
        {
            InitializeComponent();
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(CompSet);
            thread.Start();
        }

        public void CompSet()
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();

            for (int i = 0; i < Convert.ToInt32(textpoin.Text); i++)
            {
                var compset = new ComputersSet
                {
                    Firm = FirmText.Text,
                    Model = ModelText.Text,
                    Quantity = Quantity.Text,
                    Processor = Processor.Text,
                    Cost = Cost.Text,
                    RAM = RAM.Text,
                    VRAM = VRAM.Text,
                    Graphics = Graphics.Text

                };
                internetMarketDateEntities.ComputersSet.Add(compset);
                internetMarketDateEntities.SaveChanges();
            }
        }
    }
}
