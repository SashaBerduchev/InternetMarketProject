using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarketMongoServer.SERVER
{

    class ComputersData
    {
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> coll;
        private List<string> strings = new List<string>();

        public ComputersData(IMongoDatabase database)
        {
            this.database = database;
            GetColumnComputer();
        }

        private void GetColumnComputer()
        {
            coll = database.GetCollection<BsonDocument>("ComputersSet");
        }


        public async void GetComputers()
        {
            var filter = new BsonDocument();

            using (var cursor = await coll.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var comp = cursor.Current;
                    foreach (var doc in comp)
                    {
                        Trace.WriteLine("GET" + doc);
                        strings.Add(doc.ToString());
                    }
                }
            }
        }

        public async void SetComputers(string name, string model, int cost, string processor, int RAM, string GPU, int pointer)
        {
            List<BsonDocument> documents = new List<BsonDocument>();
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
                Trace.WriteLine("SEND" + doc);
            }
            await coll.InsertManyAsync(documents);
        }

        public List<string> GetList()
        {
            return strings;
        }
    }
}
