using InternetMarketMongoServer.SERVER;
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

namespace InternetMarketMongoServer.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddComputerWindow.xaml
    /// </summary>
    public partial class AddComputerWindow : Window
    {
        InternetMarketMongoService mongoService;
        public AddComputerWindow(InternetMarketMongoService mongoServer)
        {
            InitializeComponent();
            this.mongoService = mongoServer;
            Trace.WriteLine(this);
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            mongoService.SetComputers(FirmText.Text, ModelText.Text, Convert.ToInt32(Cost.Text), Processor.Text, Convert.ToInt32(RAM.Text), Graphics.Text, Convert.ToInt32(textpoin.Text));
        }
    }
}
