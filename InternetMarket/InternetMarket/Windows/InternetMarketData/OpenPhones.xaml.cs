using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InternetMarket
{
    /// <summary>
    /// Логика взаимодействия для OpenPhones.xaml
    /// </summary>
    public partial class OpenPhones : Window
    {
        private byte[] photoload;
        private byte[] arrayread;
        private InterMarketService interMarketService;
        public OpenPhones()
        {
            InitializeComponent();
            interMarketService = new InterMarketService();
            Trace.WriteLine(this);
        }

        
        private void btnset_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(textpointer.Text); i++)
            {
                Thread thread = new Thread(PhonesInsert);
                thread.Start();
                Trace.WriteLine(thread);
            }

            this.Close();
        }

        
        private void PhotoLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var picture = openFileDialog.FileName;
            try
            {
                FileStream fs = new FileStream(picture, FileMode.Open, FileAccess.Read);
                photoload = new byte[fs.Length];
                using (var reader = new BinaryReader(fs))
                {
                    photoload = reader.ReadBytes((int)fs.Length);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void PhonesInsert()
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
                    byte[] PDF = arrayread;
                    byte[] photo = photoload;
                    //InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();

                    for (int i = 0; i < Convert.ToInt32(textpointer.Text); i++)
                    {
                        interMarketService.PhonesSet(firm, model, quantity, cost, proc, ram, battery, textpointer.Text, PDF, photo);
                    }
                }catch(Exception exp)
                {
                    Trace.WriteLine(exp.ToString());
                }
            });
        }

        private void PhotoPDF_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var pdffile = openFileDialog.FileName;
            try
            {
                StreamReader sr = new StreamReader(pdffile);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    arrayread = Encoding.Default.GetBytes(line);
                }

            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

