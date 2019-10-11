using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarket.SERVER
{
    class PhoneServerData
    {
        private List<PhonesSet> phones;
        private List<string> phonedata;
        private InternetMarketDateEntities internetMarketDateEntities;
        public PhoneServerData()
        {
            internetMarketDateEntities = new InternetMarketDateEntities();
        }

        public List<string> GetPhones()
        {
            if(phones != null) phones.Clear();
            try
            {
                   phones = internetMarketDateEntities.PhonesSet.ToList();
                   Trace.WriteLine(phones);
                   Trace.WriteLine(phones.Select(x => new { x.Firm, x.Model, x.Quantity, x.Cost, x.Processor, x.RAM, x.Battery, x.Photo, x.PDF }));
                   return phones.Select(x => x.Firm + " " + x.Model + " "+ x.Quantity + " " + x.Cost + " " + x.Processor + " " +x.RAM + " " +x.Battery + " " + x.Photo + " " + x.PDF ).ToList();
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
