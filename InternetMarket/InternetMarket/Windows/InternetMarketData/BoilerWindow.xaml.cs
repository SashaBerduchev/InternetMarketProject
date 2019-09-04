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

namespace InternetMarket.Windows.InternetMarketData
{
    /// <summary>
    /// Логика взаимодействия для BoilerWindow.xaml
    /// </summary>
    public partial class BoilerWindow : Window, IDisposable
    {
        InternetMarketDateEntities internetMarketDateEntities;
        public BoilerWindow()
        {
            InitializeComponent();
        }


        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                internetMarketDateEntities = new InternetMarketDateEntities();
                Boilers boilers = new Boilers
                {
                    Name = Name.Text,
                    Model = Model.Text,
                    Volume = Volume.Text,
                    Voltage = Voltage.Text,
                    Power = Power.Text,
                    Cost = Cost.Text
                };
                internetMarketDateEntities.BoilersSet.Add(boilers);
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
