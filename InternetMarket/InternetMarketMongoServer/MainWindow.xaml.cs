using InternetMarketMongoServer.SERVER;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarketMongoServer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InternetMarketMongoService mongoServer;
        public MainWindow()
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
            mongoServer = new InternetMarketMongoService();
            Trace.WriteLine(this);
        }

        

        private void combobox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (combobox.SelectedItem.ToString() == "Phones")
            {
                Thread.Sleep(50);
                mongoServer.GetPhones();
                listbox.ItemsSource = mongoServer.GetList();
            }
        }
    }
}
