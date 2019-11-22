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

namespace InternetMarket.Loaders
{
    /// <summary>
    /// Логика взаимодействия для LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
            
        }

        public double valueMin
        {
            get
            {
                return progress.Minimum;
            }
            set
            {
                progress.Minimum = value;
            }
        }
        
        public double valueMax
        {
            get 
            {
                return progress.Maximum;
            }
            set
            {
                progress.Maximum = value;
            }
        }
    }
}
