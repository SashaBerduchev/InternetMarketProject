using InternetMarket.Loaders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace InternetMarket.SERVER
{
    class PhoneServerData : IDisposable
    {
        private List<PhonesSet> phones;
        private InternetMarketDateEntities internetMarketDateEntities;
        private int start;
        private int stop;
        private int elem;
        public PhoneServerData()
        {
            internetMarketDateEntities = new InternetMarketDateEntities();
        }

        public List<string> GetPhones()
        {
            if (phones != null) phones.Clear();
            try
            {
                LoadingWindow loadingWindow = new LoadingWindow();
                loadingWindow.valueMin = 0;
                loadingWindow.Show();
                phones = internetMarketDateEntities.PhonesSet.ToList();
                loadingWindow.valueMax = phones.Count;
                Trace.WriteLine(phones);
                Trace.WriteLine(phones.Select(x => new { x.Firm, x.Model, x.Quantity, x.Cost, x.Processor, x.RAM, x.Battery, x.Photo, x.PDF }));
                loadingWindow.Close();
                return phones.Select(x => x.Firm + " " + x.Model + " " + x.Quantity + " " + x.Cost + " " + x.Processor + " " + x.RAM + " " + x.Battery + " " + x.Photo + " " + x.PDF).ToList();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return null;
        }

        public void PhonesSet(string Firm, string Model, string Quantity, string Cost, string Processor, string RAM, string Battery, byte[] PDF, byte[] Photo)
        {
            var phonedat = new PhonesSet
            {
                Battery = Battery,
                Cost = Cost,
                Firm = Firm,
                Model = Model,
                Processor = Processor,
                Quantity = Quantity,
                RAM = RAM,
                PDF = PDF,
                Photo = Photo
            };
            Trace.WriteLine(phonedat);
            internetMarketDateEntities.PhonesSet.Add(phonedat);
            Trace.WriteLine(internetMarketDateEntities);
            internetMarketDateEntities.SaveChanges();
        }

        public void Remove(int start, int stop)
        {
            this.start = start;
            this.stop = stop;
            for (int i = this.start; i < this.stop; i++)
            {
                try
                {
                    Trace.WriteLine(phones[i]);
                    internetMarketDateEntities.PhonesSet.Remove(phones[i]);
                    internetMarketDateEntities.SaveChanges();
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

        public List<PhonesSet> GetPhonesCollection()
        {
            return phones;
        }
        public void Disable()
        {
            if (phones != null)
            {
                phones.Clear();
                phones = null;
            }
        }
        public void Dispose()
        {
            if (internetMarketDateEntities != null) internetMarketDateEntities.Dispose();
            internetMarketDateEntities = null;
            if (phones != null) phones.Clear();
            phones = null;
        }
    }
}
