using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbFramework.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarketMongoServer.SERVER
{
    class PhonesData
    {
        private List<string> strings = new List<string>();
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> coll;
        public PhonesData(IMongoDatabase database)
        {
            this.database = database;
            GetColumnPhone();
        }

        private void GetColumnPhone()
        {
            coll = database.GetCollection<BsonDocument>("PhonesSet");
        }

        public async void GetPhones()
        {
            var filter = new BsonDocument();

            using (var cursor = await coll.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var phone = cursor.Current;
                    foreach (var doc in phone)
                    {
                        Trace.WriteLine("GET" + doc);
                        strings.Add(doc.ToString());
                    }
                }
            }
        }

        public async void SetPhones(string name, string model, int cost, string processor, string battery, int pointer)
        {
            List<BsonDocument> documents = new List<BsonDocument>();
            for (int i = 0; i < pointer; i++)
            {
                BsonDocument doc = new BsonDocument();
                doc.Add(new BsonElement("Name", name));
                doc.Add(new BsonElement("Model", model));
                doc.Add(new BsonElement("Cost", cost));
                doc.Add(new BsonElement("Processor", processor));
                doc.Add(new BsonElement("Battery", battery));
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
