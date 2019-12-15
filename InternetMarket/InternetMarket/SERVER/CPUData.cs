using System;
using System.Diagnostics;
using System.Windows;

namespace InternetMarket.SERVER
{
    class CPUData : IDisposable
    {
        private InternetMarketDateEntities internetMarketDateEntities;
        public CPUData()
        {
            internetMarketDateEntities = new InternetMarketDateEntities();
        }

        public void SetCpu(string name, string architecture, string chastotatext, string corestext, string K1, string K2, string K3, string gpu, string ram, string tdp)
        {
            try
            {
                CPU cpudata = new CPU
                {
                    Name = name,
                    Architecture = architecture,
                    Chastota = chastotatext,
                    Cores = corestext,
                    KESHL1 = K1,
                    KESHL2 = K2,
                    KESHL3 = K3,
                    GPU = gpu,
                    RAM = ram,
                    TDP = tdp
                };
                internetMarketDateEntities.CPUSet.Add(cpudata);
                Trace.WriteLine(cpudata);
                internetMarketDateEntities.SaveChanges();
                Trace.WriteLine(internetMarketDateEntities);
            }catch(Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK);
            }

        }
        public void Dispose()
        {
            internetMarketDateEntities.Dispose();
        }
    }
}
