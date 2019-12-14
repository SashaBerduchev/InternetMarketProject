using System;
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
        }

        private void SetText()
        {
            textprogress.Text = "Загрузка...";
        }
    }
}
