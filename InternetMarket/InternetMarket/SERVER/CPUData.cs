using InternetMarket.Loaders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace InternetMarket.SERVER
{
    class CPUData : IDisposable
    {
        private List<CPUSet> cPUs;
        private InternetMarketDateEntities internetMarketDateEntities;
        public CPUData()
        {
            internetMarketDateEntities = new InternetMarketDateEntities();
        }

        public void SetCpu(string name, string architecture, string chastotatext, string corestext, string K1, string K2, string K3, string gpu, string ram, string tdp)
        {
            try
            {
                CPUSet cpudata = new CPUSet
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

        public List<string> GetCpu()
        {
            LoadingWindow loadingWindow = new LoadingWindow();
            loadingWindow.Show();
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            cPUs = internetMarketDateEntities.CPUSet.ToList();
            loadingWindow.Close();
            return cPUs.Select(x => x.Name + ' ' + x.Architecture + ' ' + x.Cores + ' ' + x.Chastota + ' ' + x.KESHL1 + ' ' + x.KESHL2 + ' ' + x.KESHL3 + ' ' + x.GPU + ' ' + x.RAM + ' ' + x.TDP).ToList(); ;
        }
        public void Dispose()
        {
            if (cPUs != null) cPUs.Clear();
            cPUs = null;
            internetMarketDateEntities.Dispose();
        }
    }
}
