using InternetMarket.Loaders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace InternetMarket.SERVER
{

    class TiviServerData : IDisposable
    {
        private List<TivisetSet> tivis;
        private InternetMarketEntities internetMarket;
        private IException exception;
        public TiviServerData(InternetMarketEntities internetMarket, IException exception)
        {
            this.exception = exception;
            this.internetMarket = internetMarket;
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
                exception.ExceptionWriter(exp);
            }
        }
        public List<string> GetTivis()
        {
            try
            {
                LoadingWindow loadingWindow = new LoadingWindow();
                loadingWindow.Show();
                tivis = internetMarket.TivisetSet.ToList();
                Trace.WriteLine(tivis);
                Trace.WriteLine(tivis.Select(x => new { x.Firm, x.Model, x.Quantity, x.Cost }));
                loadingWindow.Close();
                return tivis.Select(x => x.Firm + " " + x.Model + " " + x.Quantity + " " + x.Cost).ToList();
            }
            catch (Exception e)
            {
                exception.ExceptionWriter(e);
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