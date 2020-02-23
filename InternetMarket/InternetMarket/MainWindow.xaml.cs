using InternetMarket.Windows;
using InternetMarket.Windows.Administration;
using InternetMarket.Windows.Documents;
using InternetMarket.Windows.InternetMarketData;
using InternetMarket.Windows.Spravochniki;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace InternetMarket
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        private InternetMarketDateEntities internetMarketDateEntities;
        private List<string> printers;
        private InterMarketService marketService;
        private InterMarketService interMarketService;
        private List<string> strings;
        private Loading loading;
        public MainWindow(InterMarketService marketService)
        {
            interMarketService = new InterMarketService();
            this.marketService = marketService;
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
            loading = new Loading(interMarketService, this);
            Trace.WriteLine(this);
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenPhones openPhones = new OpenPhones();
            openPhones.Show();
        }

        private void OpenBtnTivi_Click(object sender, RoutedEventArgs e)
        {
            TiviWindow tiviWindow = new TiviWindow();
            tiviWindow.Show();
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            loading.LoadInfo(combobox.SelectedItem.ToString());
        }

        public void ReturnData(List<string> strings)
        {
            DataGrid.ItemsSource = strings;
        }

        private void GetCount()
        {
            countElem.Text = Convert.ToString(DataGrid.Items.Count);
        }

        private void OpenBtnComputers_Click(object sender, RoutedEventArgs e)
        {
            ComputerWindow computerWindow = new ComputerWindow();
            computerWindow.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Directors directors = new Directors();
            directors.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            CountrysData countrysData = new CountrysData();
            countrysData.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            CitiData citiData = new CitiData();
            citiData.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            OblastData oblastData = new OblastData();
            oblastData.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            RegionDat regionDat = new RegionDat();
            regionDat.Show();
        }


        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            StreetDat streetDat = new StreetDat();
            streetDat.Show();
        }

        private void OpenBtnTablets_Click(object sender, RoutedEventArgs e)
        {
            OpenTablets openTablets = new OpenTablets();
            openTablets.Show();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            DataSave dataSave = new DataSave();
            dataSave.Show();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            ContragentData contragent = new ContragentData();
            contragent.Show();
        }

        private void OpenBtnCPU_Click(object sender, RoutedEventArgs e)
        {
            AddCpuWindow cpu = new AddCpuWindow();
            cpu.Show();
        }

        private void OpenBtnGraphics_Click(object sender, RoutedEventArgs e)
        {
            GraphicsCardWindow gpuData = new GraphicsCardWindow();
            gpuData.Show();
        }

        private void OpenBtnlaptop_Click(object sender, RoutedEventArgs e)
        {
            Laptop laptop = new Laptop();
            laptop.Show();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            LoadDocument loadDocument = new LoadDocument();
            loadDocument.Show();
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            ZakazPokupatyaData zakazPokupatyaData = new ZakazPokupatyaData();
            zakazPokupatyaData.Show();
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            OrganisationData organisationData = new OrganisationData();
            organisationData.Show();

        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            SkladData skladData = new SkladData();
            skladData.Show();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (combobox.SelectedItem.ToString() == "Phones")//1
                {
                    using (FileStream fileStream = new FileStream("filetext.txt", FileMode.Append))//2
                    {
                        List<PhonesSet> phones = interMarketService.GetPhonesCollection();
                        for (int i = 0; i < phones.Count; i++)//3
                        {

                            byte[] array = System.Text.Encoding.Default.GetBytes(phones[i].ToString());//1

                            fileStream.Write(array, 0, array.Length);//2
                        }

                    }
                    MessageBox.Show("Сохранено", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (combobox.SelectedItem.ToString() == "Computers")//1
                {
                    using (FileStream fileStream = new FileStream("filetext.txt", FileMode.Append))//2
                    {
                        List<ComputersSet> computers = interMarketService.GetCompCollection(); ;
                        for (int i = 0; i < computers.Count; i++)//3
                        {

                            byte[] array = System.Text.Encoding.Default.GetBytes(computers[i].ToString());//4

                            fileStream.Write(array, 0, array.Length);//5
                        }

                    }
                    MessageBox.Show("Сохранено", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);//6
                }
            }catch(NullReferenceException nullexp)
            {
                MessageBox.Show("Выберите данные для сохранения", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Trace.WriteLine(nullexp);
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Trace.WriteLine(exp);
            }
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileStream file = new FileStream("Information.txt", FileMode.Append); //1
                string savestr; //2
                savestr = DataGrid.SelectedItem.ToString();
                for (int i = 0; i < savestr.Length; i++)
                {
                    byte[] array = Encoding.Default.GetBytes(savestr.ToString());//1
                    file.Write(array, 0, array.Length);
                }
                file.Close();//5
                MessageBox.Show("Готово", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);//6
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.StackTrace);
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);//7
            }
        }


        private void MenuItem_ClickAdministration(object sender, RoutedEventArgs e)
        {
            AdministrationWindow administrationWindow = new AdministrationWindow(loading, interMarketService);
            administrationWindow.Show();
        }

        private void OpenBtnPrinter_Click(object sender, RoutedEventArgs e)
        {
            new PrinterWindow().Show();
        }

        private void OpenBtnBoiler_Click(object sender, RoutedEventArgs e)
        {
            new BoilerWindow().Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dispose();
        }

        

        private void Window_Closed(object sender, EventArgs e)
        {
            marketService.Dispose();
            marketService = null;
        }

        public void Dispose()
        {
            if (printers != null) printers.Clear();
            printers = null;
            if (interMarketService != null) interMarketService.Dispose();
            interMarketService = null;
            if (internetMarketDateEntities != null) internetMarketDateEntities.Dispose();
            internetMarketDateEntities = null;
            if (loading != null) loading = null;

        }

        private void DeleteBttn_Click(object sender, RoutedEventArgs e)
        {

            Thread thread = new Thread(Delete);
            thread.IsBackground = true;
            thread.Start();
        }

        private void Delete()
        {
            Dispatcher.Invoke(() =>
            {
                try
                {
                    if (combobox.SelectedItem.ToString() == "Phones")
                    {
                        interMarketService.RemovePhones(Convert.ToInt32(countStartDelete.Text), Convert.ToInt32(countFinishDelete.Text));
                    }
                    else if (combobox.SelectedItem.ToString() == "Computers")
                    {
                        interMarketService.RemoveComputers(Convert.ToInt32(countStartDelete.Text), Convert.ToInt32(countFinishDelete.Text));
                    }
                    else if (combobox.SelectedItem.ToString() == "Tivis")
                    {
                        interMarketService.RemoveTivis(Convert.ToInt32(countStartDelete.Text), Convert.ToInt32(countFinishDelete.Text));
                    }
                    else if (combobox.SelectedItem.ToString() == "Tablets")
                    {
                        interMarketService.RemoveTablets(Convert.ToInt32(countStartDelete.Text), Convert.ToInt32(countFinishDelete.Text));
                    }
                    MessageBox.Show("Удалено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (NullReferenceException nullexp)
                {
                    Trace.WriteLine(nullexp.ToString());
                    MessageBox.Show("Выберите тип ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (FormatException formatexp)
                {
                    Trace.WriteLine(formatexp.ToString());
                    MessageBox.Show("Введите строку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (ArgumentOutOfRangeException argexp)
                {
                    Trace.WriteLine(argexp.ToString());
                    MessageBox.Show("Колличемство эллементов менше заданого диапазона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            });
        }

        private void OpenMail_Click(object sender, RoutedEventArgs e)
        {
            new MailWindow(strings, interMarketService).Show();
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loading.LoadInfo(combobox.SelectedItem.ToString());
        }

        private void ExpPDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Document document = new iTextSharp.text.Document();
                PdfWriter.GetInstance(document, new FileStream(combobox.SelectedItem.ToString() + ".pdf", FileMode.Create));
                document.Open();
                BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);


                //Создаем объект таблицы и передаем в нее число столбцов таблицы из нашего датасета
                PdfPTable table = new PdfPTable(DataGrid.Items.Count);
                //Добавим в таблицу общий заголовок
                PdfPCell cell = new PdfPCell(new Phrase(combobox.SelectedItem.ToString()));

                cell.Colspan = DataGrid.Items.Count;
                cell.HorizontalAlignment = 1;
                //Убираем границу первой ячейки, чтобы балы как заголовок
                cell.Border = 0;
                table.AddCell(cell);

                //Сначала добавляем заголовки таблицы
                for (int j = 0; j < DataGrid.Items.Count; j++)
                {
                    cell = new PdfPCell(new Phrase(new Phrase(DataGrid.Items.Count)));
                    //Фоновый цвет (необязательно, просто сделаем по красивее)
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);
                }

                //Добавляем все остальные ячейки
                for (int j = 0; j < DataGrid.Items.Count; j++)
                {
                    table.AddCell(new Phrase(DataGrid.Items[j].ToString(), font));
                }
                //Добавляем таблицу в документ
                document.Add(table);

                //Закрываем документ
                document.Close();

                MessageBox.Show("Pdf-документ сохранен");
            }catch(Exception exp)
            {
                Trace.WriteLine(exp.StackTrace);
                MessageBox.Show(exp.ToString());
            }
        }

        private void ExpExcel_Click(object sender, RoutedEventArgs e)
        {
            var xlApp = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                Microsoft.Office.Interop.Excel.Range xlSheetRange;
                xlApp.Workbooks.Add(Type.Missing);
                xlApp.Interactive = false;
                xlApp.EnableEvents = false;

                //выбираем лист на котором будем работать (Лист 1)
                var xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlApp.Sheets[1];
                //Название листа
                xlSheet.Name = "Book";


                int collInd = 0;
                string data = "";
                int rowInd = 0;
                //называем колонки
                for (int i = 1; i < DataGrid.Items.Count; i++)
                {
                    data = DataGrid.Items[i].ToString();
                    xlSheet.Cells[1, i + 1] = data;

                    //выделяем первую строку
                    xlSheetRange = xlSheet.get_Range("A3:Z3", Type.Missing);

                    //делаем полужирный текст и перенос слов
                    xlSheetRange.WrapText = true;
                    xlSheetRange.Font.Bold = true;


                }

                //заполняем строки
                for (collInd = 0; collInd < DataGrid.Items.Count; collInd++)
                {
                    data = DataGrid.Items[collInd].ToString();
                    xlSheet.Cells[collInd + 1, rowInd + 1] = data;

                    xlSheet.Cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot; // внутренние вертикальные
                    xlSheet.Cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot; // внутренние горизонтальные            
                    xlSheet.Cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble; // верхняя внешняя
                    xlSheet.Cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble; // правая внешняя
                    xlSheet.Cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble; // левая внешняя
                    xlSheet.Cells.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble; // нижняя внешняя

                }


                //выбираем всю область данных
                xlSheetRange = xlSheet.UsedRange;

                //выравниваем строки и колонки по их содержимому
                xlSheetRange.Columns.AutoFit();
                xlSheetRange.Rows.AutoFit();

            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.StackTrace);
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK);
            }
            finally
            {
                //Показываем ексель
                xlApp.Visible = true;

                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;

            }
        }

        internal static void MessageExp(string exp)
        {
            MessageBox.Show(exp, "Error", MessageBoxButton.OK);
        }
    }
}
