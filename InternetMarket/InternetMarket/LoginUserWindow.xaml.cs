using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;

namespace InternetMarket
{
    /// <summary>
    /// Логика взаимодействия для LoginUserWindow.xaml
    /// </summary>
    public partial class LoginUserWindow : Window
    {
        private InterMarketService interMarketService;
        private static string pass = "";
        private XmlNode xpath;
        
        public LoginUserWindow()
        {
            InitializeComponent();
            LanguageBox.Items.Add("en");
            LanguageBox.Items.Add("ru");
            LanguageBox.SelectedItem = "ru";
            Trace.WriteLine(this);
            interMarketService = new InterMarketService();
            StartConnection();
            Localization();
            LoadImage();
            //Костыль, если нету юзеров
            interMarketService.SetUserIfApsent();

            try
            {
                User.ItemsSource = interMarketService.GetUsers();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Нет подключентя к базе данных", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Trace.WriteLine(exp.StackTrace);
            }
        }

        private void LoadImage()
        {
            try
            {

                var request = WebRequest.Create("https://www.google.com/url?sa=i&url=https%3A%2F%2Fpagedesignshop.com%2Fcan-you-internet-market-through-emails%2F&psig=AOvVaw3fEk970IOghpoqyjKM8r-Q&ust=1585213810668000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCKCO_-ajtegCFQAAAAAdAAAAABAD");
                var response = request.GetResponse();
                Bitmap loadedBitmap = null;
                using (var responseStream = response.GetResponseStream())
                {
                    loadedBitmap = new Bitmap(responseStream);
                    ImageSourceConverter sourceConverter = new ImageSourceConverter();
                    Image.Source =  (ImageSource)sourceConverter.ConvertFrom(loadedBitmap);
                }
            }
            catch (System.Net.WebException ex)
            {
                Trace.WriteLine(ex);
            }
        }

        private void Localization()
        {
            try
            {
                
                XmlDocument xml = new XmlDocument();
                xml.Load(@"https://drive.google.com/uc?export=download&id=1ndgPsDs4Uhk80ZktRq9_CYT_dKmw0_Jt");
                XmlElement xRoot = xml.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    xpath = xnode;

                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.StackTrace);
                MessageBox.Show(e.ToString(), "Esception", MessageBoxButton.OK);
            }
        }

        private void StartConnection()
        {
            try
            {
                string uriAddress = "net.tcp://192.168.1.217:7000/icontract";
                //string uriAddress = "net.tcp://localhost:8000/kIContract";
                Uri addres = new Uri(uriAddress);//5
                NetTcpBinding binding = new NetTcpBinding();//6
                binding.ListenBacklog = 2000;//7
                binding.MaxConnections = 2000;//8
                binding.TransferMode = TransferMode.Buffered;//9
                binding.MaxReceivedMessageSize = 104857600;//10
                Type type = typeof(IContract);//11
                ServiceHost serviceHost = new ServiceHost(typeof(InterMarketService));//12
                serviceHost.AddServiceEndpoint(type, binding, uriAddress);//13
                serviceHost.Open();//14
                Trace.WriteLine(serviceHost);
            }catch(Exception e)
            {
                Trace.WriteLine(e.StackTrace);
            }
        }


        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                List<string> Users = interMarketService.GetUsers();
                if (interMarketService.CheckUser(User.SelectedItem.ToString(), LoginUserWindow.PasswordText))
                {
                    new MainWindow(interMarketService).Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        public void StopServer()
        {
            interMarketService.Dispose();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Dispose();
        }

        public static string PasswordText
        {
            get
            {
                return pass;
            }
        }

        private void Password_KeyUp(object sender, KeyEventArgs e)
        {
            pass = Password.Password;
        }

        private void btlLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> pass = interMarketService.GetUsers();
                if (interMarketService.CheckUser(User.SelectedItem.ToString(), LoginUserWindow.PasswordText))
                {
                    new MainWindow(interMarketService).Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (NotSupportedException)
            {
                MessageBoxResult result = MessageBox.Show("Выберите пользователя", "Error", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    this.Close();
                }

            }
            catch (NullReferenceException)
            {
                MessageBoxResult result = MessageBox.Show("Ведите пароль", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBoxResult result = MessageBox.Show("Не удалось войти в систему", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    this.Close();
                }
            }
        }
    }
}
