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
        private IException exception;
        public AdministrationWindow(Loading loading, InterMarketService marketService, IException exception)
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
            this.exception = exception;
            this.marketService = marketService;
            this.loading = new Loading(marketService, this, exception);
            marketService.StartMongoConnection();
            Userslist.ItemsSource = marketService.GetUsers();
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
                    marketService.GetPhonesMongo();
                    mongoview.ItemsSource = marketService.GetListPhoneMongo();
                }catch(Exception exp)
                {
                    Trace.WriteLine(exp);
                    exception.ExceptionWriter(exp.ToString());
                }
            }

            if (combobox.SelectedItem.ToString() == "Computers")
            {
                List<ComputersSet> phones = marketService.GetCompCollection();
                try
                {
                    for (int i = 0; i < phones.Count; i++)
                    {
                        marketService.SetComputersMongo(phones[i].Firm, phones[i].Model, Convert.ToInt32(phones[i].Cost), phones[i].Processor,Convert.ToInt32(phones[i].RAM),phones[i].Graphics, 1);
                    }
                    marketService.GetPhonesMongo();
                    mongoview.ItemsSource = marketService.GetListPhoneMongo();
                }
                catch (Exception exp)
                {
                    Trace.WriteLine(exp);
                    exception.ExceptionWriter(exp.ToString());
                }
            }
        }

    }
}
