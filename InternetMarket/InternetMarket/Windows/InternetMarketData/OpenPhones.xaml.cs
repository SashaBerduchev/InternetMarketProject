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
        public OpenPhones()
        {
            InitializeComponent();
            Trace.WriteLine(this);
        }

        byte[] photoload;
        byte[] arrayread;
        private void btnset_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(textpointer.Text); i++)
            {
                Thread thread = new Thread(PhonesInsert);
                thread.Start();
                Trace.WriteLine(thread);
            }

            OpenPhones openPhones = new OpenPhones();
            openPhones.Close();
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
                string firm = firmsettext.Text;
                string model = modelsettext.Text;
                string quantity = quantitysettext.Text;
                string cost = costsettext.Text;
                string proc = procsettext.Text;
                string ram = ramsettext.Text;
                string battery = batterysettext.Text;

                InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();

                for (int i = 0; i < Convert.ToInt32(textpointer.Text); i++)
                {
                    var phonedat = new PhonesSet
                    {
                        Battery = battery,
                        Cost = cost,
                        Firm = firm,
                        Model = model,
                        Processor = proc,
                        Quantity = quantity,
                        RAM = ram,
                        Photo = photoload,
                        PDF = arrayread
                    };
                    Trace.WriteLine(phonedat);
                    internetMarketDateEntities.PhonesSet.Add(phonedat);
                    Trace.WriteLine(internetMarketDateEntities);
                    internetMarketDateEntities.SaveChanges();
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

