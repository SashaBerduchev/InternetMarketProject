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
        private InterMarketService interMarketService;
        private string file;
        private List<string> strings;
        private List<string> servers;
        public MailWindow(List<string>strings, InterMarketService interMarketService)
        {
            this.strings = strings;
            InitializeComponent();
            this.interMarketService = interMarketService;
            listbox.ItemsSource = this.strings;
            mailfrom.ItemsSource = interMarketService.GetMail();
            mailto.ItemsSource = interMarketService.GetMail();
            servers = interMarketService.GetServers();
            server.ItemsSource = servers;
            Trace.WriteLine(this);
            if(servers.Count <= 0)
            {
                string[] servers = new string[2];
                servers[0] = "smtp.gmail.com";
                servers[1] = "smtp.ukr.net";
                interMarketService.SetServer(servers);
            }
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
                m.Body = listbox.SelectedItem.ToString();
                m.Attachments.Add(attachment);

                // письмо представляет код html
                m.IsBodyHtml = true;


                SmtpClient smtp = new SmtpClient(server.SelectedItem.ToString(), Convert.ToInt32(port.Text));
                // логин и пароль
                smtp.Credentials = new NetworkCredential(mailfrom.SelectedItem.ToString(), passfrom.Password);
                smtp.EnableSsl = checkbox.IsChecked.Value;
                smtp.Send(m);
                MessageBox.Show("Отправленно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.StackTrace);
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
            new AddEmailWindow(interMarketService).Show();
        }

        private void addServerBttn_Click(object sender, RoutedEventArgs e)
        {
            new AddMailServerWindow(interMarketService).Show();
        }
    }
}
