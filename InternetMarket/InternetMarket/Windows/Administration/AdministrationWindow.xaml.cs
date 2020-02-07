using InternetMarket.Windows.Users;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace InternetMarket.Windows.Administration
{
    /// <summary>
    /// Логика взаимодействия для AdministrationWindow.xaml
    /// </summary>
    public partial class AdministrationWindow : Window
    {
        private Loading loading;
        public AdministrationWindow(Loading loading)
        {
            this.loading = loading;
           
            InitializeComponent();
            combobox.Items.Add("Phones");
            combobox.Items.Add("Tivis");
            combobox.Items.Add("Computers");
            combobox.Items.Add("Tablets");
            combobox.Items.Add("CPU");
            combobox.Items.Add("Graphics");
            combobox.Items.Add("Laptop");
            combobox.Items.Add("Printers");
            combobox.Items.Add("Boilers");
            Trace.WriteLine(this);
        }

        private void AddUserClick(object sender, RoutedEventArgs e)
        {
            AddUserWindowServer addUserWindowServer = new AddUserWindowServer();
            addUserWindowServer.Show();
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mssqlviev.ItemsSource = loading.LoadInfo(combobox.SelectedItem.ToString());
        }
        private void btnRebaseMongo_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
