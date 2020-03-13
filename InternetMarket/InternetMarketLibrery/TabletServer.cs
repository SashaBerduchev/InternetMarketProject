using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.SERVER
{
    class TabletServer
    {
        private InternetMarketEntities internetMarket;
        public TabletServer()
        {
            internetMarket = new InternetMarketEntities();
        }

        public void SetServer(string name, string model, string proc, string ram, string gpu, string resolution, string battery)
        {
            var tabletsdata = new TabletSetSet
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
    }
}
