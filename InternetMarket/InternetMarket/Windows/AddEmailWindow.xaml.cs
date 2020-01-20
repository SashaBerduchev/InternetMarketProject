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

namespace InternetMarket.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEmailWindow.xaml
    /// </summary>
    public partial class AddEmailWindow : Window
    {
        private InterMarketService interMarket;
        public AddEmailWindow()
        {
            interMarket = new InterMarketService();
            InitializeComponent();
            Trace.WriteLine(this);
        }

        private void setbtn_Click(object sender, RoutedEventArgs e)
        {
            interMarket.SetMail(emailtext.Text);
        }
    }
}
