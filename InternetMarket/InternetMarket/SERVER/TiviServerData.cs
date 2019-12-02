using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarket.SERVER
{

    class TiviServerData : IDisposable
    {
        private List<TivisetSet> tivis;
        private InternetMarketDateEntities internetMarket;
        public TiviServerData()
        {
            internetMarket = new InternetMarketDateEntities();
        }

        public void TiviSet(string Firm, string Model, string Quantity, string Cost)
        {
            try
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
            }catch(Exception exp)
            {
                Trace.WriteLine(exp.ToString());
            }
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

        public void RemoveTivis(int start, int stop)
        {
            for (int i = start; i < stop; i++)
            {
                try
                {
                    Trace.WriteLine(tivis[i]);
                    internetMarket.TivisetSet.Remove(tivis[i]);
                    internetMarket.SaveChanges();
                }
                catch (NullReferenceException nullexp)
                {
                    Trace.WriteLine(nullexp.ToString());
                    MessageBox.Show("Загрузите данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (InvalidOperationException invalidoper)
                {
                    Trace.WriteLine(invalidoper.ToString());
                    MessageBox.Show("Элемент уже удален", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void Disable()
        {
            if (tivis != null)
            {
                tivis.Clear();
                tivis = null;
            }
        }
        public void Dispose()
        {
            if(internetMarket!= null)
            {
                internetMarket.Dispose();
                internetMarket = null;
            }

            if (tivis != null)
            {
                tivis.Clear();
                tivis = null;
            }
        }
    }
}