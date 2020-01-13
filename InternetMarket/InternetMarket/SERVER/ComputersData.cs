using InternetMarket.Loaders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarket.SERVER
{
    class ComputersData : IDisposable
    {
        private InternetMarketDateEntities internetMarketDateEntities;
        private List<ComputersSet> computers;
        private List<string> computerslist;
        public ComputersData()
        {
            internetMarketDateEntities = new InternetMarketDateEntities();
        }

        public void ComputerSet(string Firm, string Model, string Quantity, string Cost, string Processor, string RAM, string VRAM, string Graphics)
        {
            var computers = new ComputersSet
            {
                Firm = Firm,
                Model = Model,
                Processor = Processor,
                Quantity = Quantity,
                Cost = Cost,
                RAM = RAM,
                Graphics = Graphics,
                VRAM = VRAM
            };
            Trace.WriteLine(computers);
            internetMarketDateEntities.ComputersSet.Add(computers);
            Trace.WriteLine(internetMarketDateEntities);
            internetMarketDateEntities.SaveChanges();
        }

        public List<string> LoadComputers()
        {
            try
            {
                LoadingWindow loadingWindow = new LoadingWindow();
                loadingWindow.Show();
                computers = internetMarketDateEntities.ComputersSet.ToList();
                computerslist = computers.AsParallel().Select(x => x.Firm + " " + x.Model + " " + x.Processor + " " + x.Quantity + " " + x.RAM + " " + x.VRAM).ToList();
                loadingWindow.Close();
                return computerslist;
            }catch(Exception exp)
            {
                Trace.WriteLine(exp.StackTrace);
                MessageBox.Show(exp.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return null;
        }

        public List<ComputersSet> GetCompCollections()
        {
            return computers;
        }
        public void Remove(int start, int stop)
        {
            for (int i = start; i < stop; i++)
            {
                try
                {
                    Trace.WriteLine(computers[i]);
                    internetMarketDateEntities.ComputersSet.Remove(computers[i]);
                    internetMarketDateEntities.SaveChanges();
                }
                catch (NullReferenceException nullexp)
                {
                    Trace.WriteLine(nullexp.StackTrace);
                    MessageBox.Show("Загрузите данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (InvalidOperationException invalidoper)
                {
                    Trace.WriteLine(invalidoper.StackTrace);
                    MessageBox.Show("Элемент уже удален", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        public void Disable()
        {
            if(computers != null)
            {
                computers.Clear();
                computers = null;
            }
            if (computerslist != null)
            {
                computerslist.Clear();
                computerslist = null;
            }
        }
        public void Dispose()
        {
            if (computers != null) computers.Clear();
            computers = null;
            if (internetMarketDateEntities != null)internetMarketDateEntities.Dispose();
            internetMarketDateEntities = null;
        }
    }
}
