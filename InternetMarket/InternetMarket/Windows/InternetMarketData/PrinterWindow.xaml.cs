using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace InternetMarket.Windows.InternetMarketData
{
    /// <summary>
    /// Логика взаимодействия для PrinterWindow.xaml
    /// </summary>
    public partial class PrinterWindow : Window, IDisposable
    {
        private InternetMarketEntities internetMarketDateEntities;
        
        public PrinterWindow()
        {
            InitializeComponent();
            Trace.WriteLine(this);
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            Thread th = new Thread(SetData);
            th.Start();
            th.IsBackground = true;
        }

        private void SetData()
        {
            Dispatcher.Invoke(() =>
            {
                try
                {
                    internetMarketDateEntities = new InternetMarketEntities();
                    PrintersSet printers = new PrintersSet
                    {
                        Name = Name.Text,
                        Colors = Color.Text,
                        Speed = Speed.Text,
                        Cost = Cost.Text
                    };
                    internetMarketDateEntities.PrintersSet.Add(printers);
                    internetMarketDateEntities.SaveChanges();
                }catch(Exception exp)
                {
                    MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dispose();
        }

        public void Dispose()
        {
            if (internetMarketDateEntities != null) internetMarketDateEntities.Dispose();
            internetMarketDateEntities = null;
        }
    }
}
