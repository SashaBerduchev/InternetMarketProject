using System;
using System.Threading;
using System.Windows;

namespace InternetMarket
{
    /// <summary>
    /// Логика взаимодействия для TiviWindow.xaml
    /// </summary>
    public partial class TiviWindow : Window
    {
        InterMarketService interMarketService;
        public TiviWindow()
        {
            InitializeComponent();
            interMarketService = new InterMarketService();
        }

        private void btnset_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(textpointer.Text); i++)
            {
                Thread thread = new Thread(TiviInsert);
                thread.Start();
            }
                
        }


        public void TiviInsert()
        {
            Dispatcher.Invoke(() =>
            {
                string firm = firmtext.Text;
                string model = modeltext.Text;
                string quantity = quantitytext.Text;
                string cost = costtext.Text;

                interMarketService.TiviSet(firm, model, quantity, cost, textpointer.Text);

                this.Close();
            });
        }
    }
}
