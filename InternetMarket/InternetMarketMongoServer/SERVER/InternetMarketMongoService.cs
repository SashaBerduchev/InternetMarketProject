using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarketMongoServer.SERVER
{
    public class InternetMarketMongoService
    {
        private MongoClient client;
        private string con;
        private List<string> strings = new List<string>();
        public InternetMarketMongoService()
        {
            try
            {
                con = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
                client = new MongoClient(con);
                GetDatabaseNames(client).GetAwaiter();
                Trace.WriteLine("----->MONGO SERVER START<------");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Trace.WriteLine(exp.StackTrace);
            }
        }

        private static async Task GetDatabaseNames(MongoClient client)
        {
            using (var cursor = await client.ListDatabasesAsync())
            {
                var databaseDocuments = await cursor.ToListAsync();
                foreach (var databaseDocument in databaseDocuments)
                {
                    Trace.WriteLine(databaseDocument["name"]);
                }
            }
        }

        public async void GetPhones()
        {
            var database = client.GetDatabase("InternetMarket");
            var coll = database.GetCollection<BsonDocument>("PhonesSet");
            var filter = new BsonDocument();

            using (var cursor = await coll.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var phone = cursor.Current;
                    foreach (var doc in phone)
                    {
                        strings.Add(doc.ToString());
                    }
                }
            }
        }

        public List<string> GetList()
        {
            return strings;
        }
    }
}