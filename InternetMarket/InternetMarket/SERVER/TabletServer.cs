using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarket.SERVER
{
    class TabletServer : IDisposable
    {
        private List<TabletSet> tablets;
        private InternetMarketDateEntities internetMarket;
        public TabletServer()
        {
            internetMarket = new InternetMarketDateEntities();
        }

        public void SetTablet(string name, string model, string proc, string ram, string gpu, string resolution, string battery)
        {
            var tabletsdata = new TabletSet
            {
                Name = name,
                Model = model,
                Processor = proc,
                Battery = battery,
                GPU = gpu,
                RAM = ram,
                Resolution = resolution
            };
            Trace.WriteLine(tabletsdata);
            internetMarket.TabletSetSet.Add(tabletsdata);
            Trace.WriteLine(internetMarket);
            internetMarket.SaveChanges();
        }

        public List<string> LoadTablets()
        {
            try
            {
                InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
                tablets = internetMarketDateEntities.TabletSetSet.ToList();
                Trace.WriteLine(tablets);
                Trace.WriteLine(tablets.Select(x => new { x.Name, x.Model, x.Processor, x.RAM, x.GPU, x.Battery, x.Resolution }));
                return tablets.Select(x => x.Name +" "+ x.Model+ " " + x.Processor+ " "+ x.RAM+" "+ x.GPU+" "+ x.Battery+" "+ x.Resolution ).ToList();
            }catch(Exception exp)
            { 
                Trace.WriteLine(exp.ToString());
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return null;
        }

        public void Disable()
        {
            if (tablets != null) tablets.Clear();
            tablets = null;
        }

        public void Dispose()
        {
            if (internetMarket != null) internetMarket.Dispose();
            internetMarket = null;
            if (tablets != null) tablets.Clear();
            tablets = null;
        }
    }
}
