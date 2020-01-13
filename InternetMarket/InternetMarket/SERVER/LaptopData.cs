using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarket.SERVER
{
    class LaptopData : IDisposable
    {
        private InternetMarketDateEntities internetMarket;
        public LaptopData()
        {
            internetMarket = new InternetMarketDateEntities();
        }


        public void LeptopSet(string name, string battery, string  gpu, string model, string proc, string ram, string resolution, string screen, string vram)
        {
            try
            {
                Laptops laptops = new Laptops
                {
                    Name = name,
                    Battery = battery,
                    GPU = gpu,
                    Model = model,
                    Procc = proc,
                    RAM = ram,
                    Resolution = resolution,
                    SCREEN = screen,
                    VRAM = vram
                };
                Trace.WriteLine(laptops);
                internetMarket.LaptopsSet.Add(laptops);
                Trace.WriteLine(internetMarket);
                internetMarket.SaveChanges();
            }catch(Exception exp)
            {
                Trace.WriteLine(exp.StackTrace);
                MessageBox.Show(exp.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Dispose()
        {
            internetMarket.Dispose();
            internetMarket = null;
        }
    }
}
