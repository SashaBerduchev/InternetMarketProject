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
        private List<Laptops> laptops;
        public LaptopData()
        {
            internetMarket = new InternetMarketDateEntities();
        }


        public void LeptopSet(string name, string battery, string gpu, string model, string proc, string ram, string resolution, string screen, string vram)
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
            } catch (Exception exp)
            {
                Trace.WriteLine(exp.StackTrace);
                MessageBox.Show(exp.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<string> GetLaptop()
        {

            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();//4
            laptops = internetMarketDateEntities.LaptopsSet.ToList();
            List<string> laptopslist = laptops.Select(x => x.Name + " " + x.Model + " " + x.Procc + " " + x.RAM + " " + x.Resolution + " " + x.SCREEN + " " + x.VRAM + " " + x.Battery).ToList();
            return laptopslist;
        }
        public void Dispose()
        {
            if (internetMarket != null) internetMarket.Dispose();
            internetMarket = null;
            if (laptops != null) laptops.Clear();
            laptops = null;
        }
    }
}
