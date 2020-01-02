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
        private int _count;
        private List<PhonesSet> phoneses;
        public PhoneServerData()
        {
            internetMarketDateEntities = new InternetMarketDateEntities();
            phoneses = new List<PhonesSet>();

        }

        public Task<List<string>> GetPhones()
        {
            try
            {
                LoadingWindow loadingWindow = new LoadingWindow();
                loadingWindow.Show();
                Task<Task<List<string>>> task = new Task<Task<List<string>>>(() => PhonesLoading());
                task.Start();
                task.Wait();
                phonesdat = task.GetAwaiter().GetResult();;
                loadingWindow.Close();
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
            phones = Phone();
            return phones;
        }

        private List<string> Phone()
        {
            Trace.WriteLine("TASK RUn");
            phones = internetMarketDateEntities.PhonesSet.ToList();
            Trace.WriteLine(phones.Select(x => new { x.Firm, x.Model, x.Quantity, x.Cost, x.Processor, x.RAM, x.Battery, x.Photo, x.PDF }));
            Trace.WriteLine("TASK STOP!!");
            return phones.Select(x => x.Firm + ' ' + x.Model + ' ' + x.Quantity + ' ' + x.Cost + ' ' + x.Processor + ' ' + x.RAM + ' ' + x.Battery + ' ' + x.Photo + ' ' + x.PDF).ToList();
        }

        public async void PhonesSet(string Firm, string Model, string Quantity, string Cost, string Processor, string RAM, string Battery, byte[] PDF, byte[] Photo, int count)
        {
            _count = count;   
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
            phoneses.Add(phonedat);
            Trace.WriteLine(phonedat);

        }

        
        public void PhonesSetAllData()
        {
            Thread.Sleep(1000);
            if (Check() == false) return;
            internetMarketDateEntities.PhonesSet.AddRange(phoneses);
            Trace.WriteLine(internetMarketDateEntities);
            internetMarketDateEntities.SaveChanges();
            if (phoneses != null) phoneses.Clear();
        }

        private bool Check()
        {
            if (phoneses.Count >= _count)
                return true;
            return false;
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