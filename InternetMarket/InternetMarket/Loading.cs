using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarket
{
    public class Loading
    {
        private List<string> strings;
        private InterMarketService interMarketService;
        public Loading(InterMarketService interMarketService)
        {
            this.interMarketService = interMarketService;
        }

        public List<string> LoadInfo(string type)
        {
            try
            {
                if (type == "Phones")
                {
                    GetPhones();

                }
                else if (type == "Tivis")
                {
                    GetTivis();
                }
                else if (type == "Computers")
                {
                    GetComputers();
                }

                else if (type == "Tablets")
                {
                    GetTablets();
                }

                else if (type == "CPU")
                {
                    GetCPUInform();
                }
                else if (type == "Graphics")
                {
                    GetGraphicsCardInform();
                }

                else if (type == "Laptop")
                {
                    GetLaptop();
                }
                else if (type == "Printers")
                {
                    GetPrinters();

                }
                else if (type == "Boilers")
                {
                    GetBoilers();
                }
                return strings;
            }
            catch (Exception exp)
            {
                if (exp is NullReferenceException)
                {
                    MessageBox.Show("Выбирите нужный параметр загрузки", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Trace.WriteLine(exp.ToString());
                }
                else
                {
                    MessageBox.Show(exp.ToString(), "NotIdentityError", MessageBoxButton.OK, MessageBoxImage.Error);
                    Trace.WriteLine(exp.ToString());
                }
            }
            return null;
        }

        private void GetBoilers()
        {
            List<string> boilers = new List<string>();
            boilers = interMarketService.GetBoilersData();

        }

        public void GetPhones()
        {
            strings = interMarketService.LoadPhones().GetAwaiter().GetResult();
        }

        public void GetTivis()
        {
            strings = interMarketService.LoadTivis();
            

        }
        public void GetTablets()
        {
            try
            {
                strings = interMarketService.LoadTablets();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void GetComputers()
        {
            try
            {
                strings = interMarketService.LoadComputers();
                
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void GetCPUInform()
        {
            try
            {
                strings = interMarketService.LoadCPU();
                
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void GetGraphicsCardInform()
        {
            try
            {
                strings = interMarketService.LoadGPU();
                
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);//6
            }
        }


        public void GetLaptop()
        {
            try
            {
                strings = interMarketService.GetLaptop();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);//7
            }
        }

        private void GetPrinters()
        {
            
        }
    }
}

