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
        public TiviWindow()
        {
            InitializeComponent();
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

                InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
                for (int i = 0; i < Convert.ToInt32(textpointer.Text); i++)
                {
                    var tividata = new TivisetSet
                    {
                        Cost = cost,
                        Model = model,
                        Firm = firm,
                        Quantity = quantity
                    };
                    internetMarketDateEntities.TivisetSet.Add(tividata);
                    internetMarketDateEntities.SaveChanges();
                    TiviWindow tiviWindow = new TiviWindow();
                    tiviWindow.Close();
                }
            });
        }
    }
}
