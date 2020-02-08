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
        private InternetMarketDateEntities internetMarket;
        public TabletServer()
        {
            internetMarket = new InternetMarketDateEntities();
        }

        public void SetServer(string name, string model, string proc, string ram, string gpu, string resolution, string battery)
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
    }
}
