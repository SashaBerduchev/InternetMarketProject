using System;
using System.Diagnostics;
using System.Windows;

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
            SetText();
            Trace.WriteLine(this);
            Trace.WriteLine("ADD LOADER");
        }

        private void SetText()
        {
            textprogress.Text = "Загрузка...";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Trace.WriteLine("REMOVE LOADER");
        }
    }
}
