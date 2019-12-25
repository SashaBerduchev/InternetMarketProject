using InternetMarket.Loaders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarket.SERVER
{
    class PhoneServerData : IDisposable
    {
        private static List<PhonesSet> phones;
        private static Task<List<string>> phonesdat;
        private InternetMarketDateEntities internetMarketDateEntities;
        private int start;
        private int stop;
        public PhoneServerData()
        {
            internetMarketDateEntities = new InternetMarketDateEntities();
        }

        public Task<List<string>> GetPhones()
        {
            try
            {
                //LoadingWindow loadingWindow = new LoadingWindow();
                //loadingWindow.Show();
               phonesdat = Task.Run(() => PhonesLoading());
                //Thread.Sleep(10000);
                //loadingWindow.Close();
                return phonesdat;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return null;
        }

        async Task<List<string>> PhonesLoading()
        {
            List<string> phones;
            Trace.WriteLine("TASK START!!");
            phones =  Phone();
            return phones;
        }

        private List<string> Phone()
        {
            Trace.WriteLine("TASK RUn");
            phones = internetMarketDateEntities.PhonesSet.ToList();
            Trace.WriteLine(phones.Select(x => new { x.Firm, x.Model, x.Quantity, x.Cost, x.Processor, x.RAM, x.Battery, x.Photo, x.PDF }));
            Trace.WriteLine("TASK STOP!!");
            return phones.Select(x => x.Firm+' '+ x.Model+' '+ x.Quantity + ' ' + x.Cost + ' ' + x.Processor + ' ' + x.RAM + ' ' + x.Battery + ' ' + x.Photo + ' ' + x.PDF ).ToList();
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
            phonesdat = null;
            if (internetMarketDateEntities != null) internetMarketDateEntities.Dispose();
            internetMarketDateEntities = null;
            if (phones != null) phones.Clear();
            phones = null;
        }
    }
}
