using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.SERVER
{
    class ComputersData : IDisposable
    {
        private InternetMarketEntities internetMarketDateEntities;
        private List<ComputersSet> computers;
        private List<string> computerslist;
        public ComputersData()
        {
            internetMarketDateEntities = new InternetMarketEntities();
        }

        public void ComputerSet(string Firm, string Model, string Quantity, string Cost, string Processor, string RAM, string VRAM, string Graphics)
        {
            var computers = new ComputersSet
            {
                Firm = Firm,
                Model = Model,
                Processor = Processor,
                Quantity = Quantity,
                Cost = Cost,
                RAM = RAM,
                Graphics = Graphics,
                VRAM = VRAM
            };
            Trace.WriteLine(computers);
            internetMarketDateEntities.ComputersSet.Add(computers);
            Trace.WriteLine(internetMarketDateEntities);
            internetMarketDateEntities.SaveChanges();
        }

        public List<string> LoadComputers()
        {
            computers = internetMarketDateEntities.ComputersSet.ToList();
            computerslist = computers.AsParallel().Select(x => x.Firm + " " + x.Model + " " + x.Processor + " " + x.Quantity + " " + x.RAM + " " + x.VRAM).ToList();
            return computerslist;
        }

        public void Dispose()
        {
            if (computers != null) computers.Clear();
            computers = null;
            if (internetMarketDateEntities != null)internetMarketDateEntities.Dispose();
            internetMarketDateEntities = null;
        }
    }
}
