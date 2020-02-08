using Microsoft.Win32;
using System;
using System.IO;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows;

namespace InternetMarketClient
{
    /// <summary>
    /// Логика взаимодействия для OpenPhones.xaml
    /// </summary>
    public partial class OpenPhones : Window
    {
        IContract contract;
        private byte[] pdffile;
        private byte[] photo;
        public OpenPhones()
        {
            //Uri uri = new Uri("net.tcp://localhost:4000/IContract");
            //NetTcpBinding netTcpBinding = new NetTcpBinding();
            //EndpointAddress endpoint = new EndpointAddress(uri);
            //ChannelFactory<IContract> factory = new ChannelFactory<IContract>(netTcpBinding, endpoint);
            //contract = factory.CreateChannel();


            InitializeComponent();
        }

        private void btnset_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                System.Net.ServicePointManager.DefaultConnectionLimit = 999999999;

                for (int i = 0; i < Convert.ToInt32(textpoint.Text); i++)
                {
                    Thread thread = new Thread(Set);
                    thread.Start();
                }
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            OpenPhones openPhones = new OpenPhones();
            openPhones.Close();
        }

        public void Set()
        {
            Dispatcher.Invoke(() =>
            {
                try
                {
                    string firm = firmsettext.Text;
                    string model = modelsettext.Text;
                    string quantity = quantitysettext.Text;
                    string cost = costsettext.Text;
                    string proc = procsettext.Text;
                    string ram = ramsettext.Text;
                    string battery = batterysettext.Text;
                    contract.PhonesSet(firm, model, quantity, cost, proc, ram, battery, textpoint.Text, pdffile, photo);
                }catch(Exception exp)
                {
                    MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
           
        }

        private void AddPdfFileBttn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var pdfopen = openFileDialog.FileName;
            try
            {
                StreamReader sr = new StreamReader(pdfopen);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    pdffile = Encoding.Default.GetBytes(line);
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddPhotoFileBttn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var picture = openFileDialog.FileName;
            try
            {
                FileStream fs = new FileStream(picture, FileMode.Open, FileAccess.Read);
                pdffile = new byte[fs.Length];
                using (var reader = new BinaryReader(fs))
                {
                    pdffile = reader.ReadBytes((int)fs.Length);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
