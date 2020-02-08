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
            try
            {
                coll = database.GetCollection<BsonDocument>("PhonesSet");
            }catch(Exception exp)
            {
                Trace.WriteLine(exp.StackTrace);
                IException exception = new MainException();
                exception.ExceptionWriter(exp.ToString());
            }
        }

        public async void GetPhones()
        {
            var filter = new BsonDocument();

            using (var cursor = await coll.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var phone = cursor.Current;
                    Trace.WriteLine(phone);
                    Trace.WriteLine("GET" + "{");
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
            Trace.WriteLine("SEND" + "{");
            for (int i = 0; i < pointer; i++)
            {
                BsonDocument doc = new BsonDocument();
                doc.Add(new BsonElement("Name", name));
                doc.Add(new BsonElement("Model", model));
                doc.Add(new BsonElement("Cost", cost));
                doc.Add(new BsonElement("Processor", processor));
                doc.Add(new BsonElement("Battery", battery));
                documents.Add(doc);
                Trace.WriteLine(doc);
            }
            await coll.InsertManyAsync(documents);
        }

        public List<string> GetList()
        {
            return strings;
        }
    }
}
