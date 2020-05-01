using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarket.SERVER
{

    class TiviServerData
    {
        private List<TivisetSet> tivis;
        private InternetMarketEntities internetMarket;
        public TiviServerData()
        {
            internetMarket = new InternetMarketEntities();
        }

        public void TiviSet(string Firm, string Model, string Quantity, string Cost)
        {
            var dataset = new TivisetSet
            {
                Cost = Cost,
                Firm = Firm,
                Model = Model,
                Quantity = Quantity
            };
            Trace.WriteLine(dataset);
            internetMarket.TivisetSet.Add(dataset);
            Trace.WriteLine(internetMarket);
            internetMarket.SaveChanges();
        }
        public List<string> GetTivis()
        {
            try
            {

                tivis = internetMarket.TivisetSet.ToList();
                Trace.WriteLine(tivis);
                Trace.WriteLine(tivis.Select(x => new { x.Firm, x.Model, x.Quantity, x.Cost }));
                return tivis.Select(x => x.Firm + " " + x.Model + " " + x.Quantity + " " + x.Cost).ToList();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return null;
        }
    }
}