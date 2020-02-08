using InternetMarketMongoServer.SERVER;
using System;
using System.Windows;

namespace InternetMarketMongoServer.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPhoneWindow.xaml
    /// </summary>
    public partial class AddPhoneWindow : Window
    {
        private InternetMarketMongoService mongoServer;
        public AddPhoneWindow(InternetMarketMongoService mongoServer)
        {
            this.mongoServer = mongoServer;
            InitializeComponent();
        }

        private void btnset_Click(object sender, RoutedEventArgs e)
        {
            mongoServer.SetPhones(firmsettext.Text, modelsettext.Text, Convert.ToInt32(costsettext.Text), procsettext.Text, batterysettext.Text, Convert.ToInt32(textpointer.Text));
        }
    }
}
