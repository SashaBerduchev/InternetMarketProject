using InternetMarket.Loaders;
using MongoDB.Bson;
using MongoDB.Driver;
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
        private IMongoCollection<BsonDocument> coll;
        private List<string> strings;

        public ComputersData(InternetMarketDateEntities internetMarket)
        {
            this.internetMarketDateEntities = internetMarket;
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
            }
            catch (Exception exp)
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


        public void GetMongoCollection(IMongoCollection<BsonDocument> coll)
        {
            this.coll = coll;
        }

        public async void GetComputersMongo()
        {
            strings = new List<string>();
            var filter = new BsonDocument();

            using (var cursor = await coll.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var comp = cursor.Current;
                    Trace.WriteLine(comp);
                    Trace.WriteLine("GET" + "{");
                    foreach (var doc in comp)
                    {
                        Trace.WriteLine("GET" + doc);
                        strings.Add(doc.ToString());
                    }
                }
            }
        }

        public async void SetComputersMongo(string name, string model, int cost, string processor, int RAM, string GPU, int pointer)
        {
            List<BsonDocument> documents = new List<BsonDocument>();
            Trace.WriteLine("SEND" + "{");
            for (int i = 0; i < pointer; i++)
            {
                BsonDocument doc = new BsonDocument();
                doc.Add(new BsonElement("Name", name));
                doc.Add(new BsonElement("Model", model));
                doc.Add(new BsonElement("Cost", cost));
                doc.Add(new BsonElement("Processor", processor));
                doc.Add(new BsonElement("RAM", RAM));
                doc.Add(new BsonElement("GPU", GPU));
                documents.Add(doc);
                Trace.WriteLine(doc);

            }
            await coll.InsertManyAsync(documents);
        }
        public void Dispose()
        {
            if (computers != null) computers.Clear();
            computers = null;
        }

        public List<string> GetListMongo()
        {
            return strings;
        }
        public void Disable()
        {
            if (computers != null)
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
    }
}
