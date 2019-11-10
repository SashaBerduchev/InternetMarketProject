using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarket.SERVER
{
    class PhoneServerData : IDisposable
    {
        private List<PhonesSet> phones;
        private InternetMarketDateEntities internetMarketDateEntities;
        public PhoneServerData()
        {
            internetMarketDateEntities = new InternetMarketDateEntities();
        }

        public List<string> GetPhones()
        {
            if (phones != null) phones.Clear();
            try
            {
                phones = internetMarketDateEntities.PhonesSet.ToList();
                Trace.WriteLine(phones);
                Trace.WriteLine(phones.Select(x => new { x.Firm, x.Model, x.Quantity, x.Cost, x.Processor, x.RAM, x.Battery, x.Photo, x.PDF }));
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


        public void Dispose()
        {
            if (internetMarketDateEntities != null) internetMarketDateEntities.Dispose();
            internetMarketDateEntities = null;
            if (phones != null) phones.Clear();
            phones = null;
        }
    }
}
