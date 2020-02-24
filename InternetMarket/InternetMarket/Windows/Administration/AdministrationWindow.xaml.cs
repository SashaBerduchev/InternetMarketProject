using InternetMarket.Windows.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private InterMarketService marketService;
        public AdministrationWindow(Loading loading, InterMarketService marketService)
        {
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
            this.marketService = marketService;
            this.loading = new Loading(marketService, this);
            marketService.StartMongoConnection();
            Trace.WriteLine(this);
        }

        private void AddUserClick(object sender, RoutedEventArgs e)
        {
            AddUserWindowServer addUserWindowServer = new AddUserWindowServer();
            addUserWindowServer.Show();
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loading.LoadInfo(combobox.SelectedItem.ToString());
        }

        public void ReturnData(List<string> strings)
        {
            mssqlviev.ItemsSource = strings;
        }
        private void btnRebaseMongo_Click(object sender, RoutedEventArgs e)
        {
            if(combobox.SelectedItem.ToString() == "Phones")
            {
                List<PhonesSet> phones = marketService.GetPhonesCollection();
                try
                {
                    for (int i = 0; i < phones.Count; i++)
                    {
                        marketService.SetPhonesMongo(phones[i].Firm, phones[i].Model, Convert.ToInt32(phones[i].Cost), phones[i].Processor, phones[i].Battery, 1);
                    }
                    mongoview.ItemsSource = marketService.GetListMongo();
                }catch(Exception exp)
                {
                    Trace.WriteLine(exp);
                }

            }
        }

    }
}
