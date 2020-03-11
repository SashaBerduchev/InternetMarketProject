using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.SERVER
{
    class CountryData
    {
        private List<CountrySet> countries;
        private InternetMarketEntities internetMarket;
        public CountryData(InternetMarketEntities internetMarket)
        {
            this.internetMarket = internetMarket;
        }

        public void CountrySet(string country)
        {
            CountrySet countrydata = new CountrySet
            {
                NameCountry = country
            };
            Trace.WriteLine(countrydata);
            Trace.WriteLine(this);
            internetMarket.CountrySet.Add(countrydata);
            internetMarket.SaveChanges();
        }

        public List<string> GetCountry()
        {
            countries = internetMarket.CountrySet.ToList();
            return countries.Select(x => x.NameCountry).ToList();
        }
    }
}
