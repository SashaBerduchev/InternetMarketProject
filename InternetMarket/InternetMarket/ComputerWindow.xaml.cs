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

            string firm = firmsettext.Text;
            string model = modelsettext.Text;
            string quantity = quantitysettext.Text;
            string cost = costsettext.Text;
            string proc = procsettext.Text;
            string ram = ramsettext.Text;
            string vram = vramsettext.Text;
            string graphics = graphicsettext.Text;
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
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

            ComputerWindow computerWindow = new ComputerWindow();
            computerWindow.Close();
        }
    }
}
