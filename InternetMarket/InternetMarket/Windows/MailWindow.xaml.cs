using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InternetMarket.Windows
{
    /// <summary>
    /// Логика взаимодействия для MailWindow.xaml
    /// </summary>
    public partial class MailWindow : Window
    {
        InterMarketService interMarketService;
        string file;
        public MailWindow()
        {
            InitializeComponent();
            interMarketService = new InterMarketService();

            mailfrom.ItemsSource = interMarketService.GetMail();
            mailto.ItemsSource = interMarketService.GetMail();

            Trace.WriteLine(this);
        }

        private void BtnAttach_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            file = openFileDialog.FileName;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailAddress from = new MailAddress(mailfrom.SelectedItem.ToString());
                MailAddress to = new MailAddress(mailto.SelectedItem.ToString());
                MailMessage m = new MailMessage(from, to);
                Attachment attachment = new Attachment(file, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = attachment.ContentDisposition;
                disposition.CreationDate = File.GetCreationTime(file);
                disposition.ModificationDate = File.GetLastWriteTime(file);
                disposition.ReadDate = File.GetLastAccessTime(file);
                m.Body = datagrid.SelectedItem.ToString();
                m.Attachments.Add(attachment);

                // письмо представляет код html
                m.IsBodyHtml = true;


                SmtpClient smtp = new SmtpClient(server.Text, Convert.ToInt32(port.Text));
                // логин и пароль
                smtp.Credentials = new NetworkCredential(mailfrom.SelectedItem.ToString(), passfrom.Password);
                smtp.EnableSsl = checkbox.IsChecked.Value;
                smtp.Send(m);
                MessageBox.Show("Отправленно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                string expstr = exp.ToString();
                FileStream fileStreamLog = new FileStream(@"Mail.log", FileMode.Append);
                for (int i = 0; i < expstr.Length; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(expstr.ToString());
                    fileStreamLog.Write(array, 0, array.Length);
                }
                fileStreamLog.Close();
            }

        }

        private void AddEmail_Click(object sender, RoutedEventArgs e)
        {
            new AddEmailWindow().Show();
        }
    }
}
