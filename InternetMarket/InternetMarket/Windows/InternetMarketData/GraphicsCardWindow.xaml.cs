﻿using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;

namespace InternetMarket.Windows.InternetMarketData
{
    /// <summary>
    /// Логика взаимодействия для GraphicsCardWindow.xaml
    /// </summary>
    public partial class GraphicsCardWindow : Window
    {
        private byte[] photoload;
        private byte[] arrayread;
        private InterMarketService interMarket;
        public GraphicsCardWindow()
        {
            InitializeComponent();
            interMarket = new InterMarketService();
            Trace.WriteLine(this);
        }


        private void BtnPhoto_Click(object sender, RoutedEventArgs e)
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
        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(pointtext.Text); i++)
            {
                Thread thread = new Thread(SetGPUData);
                thread.Start();
            }
        }

        private void BtnFile_Click(object sender, RoutedEventArgs e)
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
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void SetGPUData()
        {
            Dispatcher.Invoke(() =>
            {
                InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();

                for (int i = 0; i < Convert.ToInt32(pointtext.Text); i++)
                {
                    interMarket.GraphicsCardSet(namegpu.Text, cores.Text, gpucores.Text, herts.Text, vram.Text, voltage.Text, Convert.ToInt32(pointtext.Text), photoload, arrayread);
                }
            });
        }


    }
}