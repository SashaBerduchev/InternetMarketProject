using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarket.SERVER
{
    
    class BoilerServerData
    {
        private InternetMarketDateEntities internetMarket;
        public BoilerServerData()
        {
            internetMarket = new InternetMarketDateEntities();
        }

        public void BoilersSet(string Name, string Model, string Volume, string Voltage, string Power, string Cost)
        {
            try
            {
                internetMarket = new InternetMarketDateEntities();
                Boilers boilers = new Boilers
                {
                    Name = Name,
                    Model = Model,
                    Volume = Volume,
                    Voltage = Voltage,
                    Power = Power,
                    Cost = Cost
                };
                Trace.WriteLine(boilers);
                internetMarket.BoilersSet.Add(boilers);
                Trace.WriteLine(internetMarket);
                internetMarket.SaveChanges();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<string> GetBoilers()
        {
            return internetMarket.BoilersSet.Select(x => x.Name + " " + x.Model + " " + x.Voltage + " " + x.Volume + " " + x.Cost).ToList();
        }
    }
}
