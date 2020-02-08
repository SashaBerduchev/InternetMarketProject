using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbFramework.Abstractions;
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
    public class InternetMarketMongoService : IContract
    {
        private MongoClient client;
        private string con;
        private IMongoDatabase database;
        private PhonesData phones;
        private ComputersData computers;
        public InternetMarketMongoService()
        {
            try
            {
                con = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
                client = new MongoClient(con);
                GetDatabaseNames(client).GetAwaiter();
                StartConnection();
                StartServer();
                Trace.WriteLine("----->MONGO SERVER START<------");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Trace.WriteLine(exp.StackTrace);
            }
        }

        private void StartConnection()
        {
            try
            {
                database = client.GetDatabase("InternetMarket");
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.StackTrace);
            }
        }

        private void StartServer()
        {
            phones = new PhonesData(database);
            computers = new ComputersData(database);
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
            phones.GetPhones();
        }

        public async void SetPhones(string name, string model, int cost, string processor, string battery, int point)
        {
            phones.SetPhones(name, model, cost, processor, battery, point);
        }
        public List<string> GetListPhones()
        {
            return phones.GetList();
        }

        public async void GetComputers()
        {
            computers.GetComputers();
        }

        public async void SetComputers(string name, string model, int cost, string processor, int RAM, string GPU, int pointer)
        {
            computers.SetComputers(name, model, cost, processor, RAM, GPU, pointer);
        }
        public List<string> GetCompList()
        {
            return computers.GetList();
        }
    }
}