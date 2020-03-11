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

namespace InternetMarket.Windows
{
    /// <summary>
    /// Логика взаимодействия для Laptop.xaml
    /// </summary>
    public partial class Laptop : Window
    {
        public Laptop()
        {
            InitializeComponent();
            Trace.WriteLine(this);
        }

        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(pointertext.Text); i++)
            {
                Thread thread = new Thread(SetLaptop);
                Trace.WriteLine(thread);
                thread.Start();
            }
        }

        public void SetLaptop()
        {
            Dispatcher.Invoke(() =>
            {
                for (int i=0; i<Convert.ToInt32(pointertext.Text); i++)
                {
                    InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
                    var laptopedat = new LaptopsSet
                    {
                        Name = namelaptom.Text,
                        Model = modellaptom.Text,
                        Procc = procclaptom.Text,
                        RAM = ramlaptom.Text,
                        GPU = gpulaptom.Text,
                        VRAM = vramlaptom.Text,
                        Resolution = resolutionlaptom.Text,
                        SCREEN = screenlaptom.Text,
                        Battery = baterrylaptom.Text
                    };
                    try
                    {
                        Trace.WriteLine(laptopedat);
                        internetMarketDateEntities.LaptopsSet.Add(laptopedat);
                        Trace.WriteLine(internetMarketDateEntities);
                        internetMarketDateEntities.SaveChanges();
                    }catch (Exception exp)
                    {
                        Trace.WriteLine(exp.ToString());
                        MessageBox.Show(exp.ToString(),"Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            });
        }
    }
}
