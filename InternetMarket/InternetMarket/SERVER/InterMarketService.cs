using InternetMarket.SERVER;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace InternetMarket
{
    public class InterMarketService : IContract , IDisposable
    {
        private IException exception;
        private string con;
        private IMongoDatabase database;
        private MongoClient client;
        private PhoneServerData phoneServerData;
        private TiviServerData tiviServer;
        private UserServerData userServer;
        private TabletServer tabletServer;
        private BoilerServerData boilerServer;
        private ComputersData computersData;
        private InternetMarketDateEntities internetMarketDateEntities;
        private List<string> users;
        private List<CPUSet> cpu;
        private List<Country> countries;
        private List<CityData> cities;
        private List<string> listgpu;
        private List<GraphicsCard> graphics;
        private CPUData CPU;
        private GPUData graphicsCard;
        private LaptopData laptopData;
        private MailData mailData;
        private CountryData countryData;
        public InterMarketService()
        {
            internetMarketDateEntities = new InternetMarketDateEntities();
            phoneServerData = new PhoneServerData(internetMarketDateEntities, exception);
            tiviServer = new TiviServerData(internetMarketDateEntities, exception);
            userServer = new UserServerData();
            tabletServer = new TabletServer();
            boilerServer = new BoilerServerData(internetMarketDateEntities);
            computersData = new ComputersData(internetMarketDateEntities);
            CPU = new CPUData();
            graphicsCard = new GPUData();
            laptopData = new LaptopData();
            mailData = new MailData();
            countryData = new CountryData(internetMarketDateEntities);
            exception = new MainException();
            Trace.WriteLine(this);
            Trace.WriteLine("Server INITIALIZE");
        }

        public void StartMongoConnection()
        {
            try
            {
                con = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
                client = new MongoClient(con);
                GetDatabaseNames(client).GetAwaiter();
                StartConnection();
                Trace.WriteLine("----->MONGO SERVER START<------");
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.StackTrace);
            }
        }

        private void StartConnection()
        {
            try
            {
                database = client.GetDatabase("InternetMarket");
                phoneServerData.GetMongoCollection(database.GetCollection<BsonDocument>("PhoneSet"));
            }
            catch (Exception exp)
            {
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

        public void SetPhonesMongo(string name, string model, int cost, string processor, string battery, int pointer)
        {
            phoneServerData.SetPhonesMongo(name, model, cost, processor, battery, pointer);
        }

        public void GetPhonesMongo()
        {
            phoneServerData.GetPhonesMongo();
        }

        public List<String> GetListMongo()
        {
            return phoneServerData.GetListMongo();
        }
        public void SetUserIfApsent()
        {
            userServer.SetUserIfApsent();
        }
        public bool SetUserLogin(string login, string pass)
        {
            ClearContent();
            return userServer.SetUser(login, pass);
        }


        public List<string> GetUsers()
        {
            DisableData();
            List<string> users = userServer.GetUsers();
            if(users != null)
            {
                return users;
            }
            return null;
        }
        
        public bool CheckUser(string login, string pass)
        {
            return userServer.CheckUser(login, pass);
        }
        public  Task<List<string>> LoadPhones()
        {
            return  phoneServerData.GetPhones();
        }

        public List<PhonesSet> GetPhonesCollection()
        {
            return phoneServerData.GetPhonesCollection();
        }
        public void PhonesSet(string Firm, string Model, string Quantity, string Cost, string Processor, string RAM, string Battery, string texpoint, byte[] PDF, byte[] Photo)
        {
            Task[] tasks = new Task[Convert.ToInt32(texpoint)];
            for (int i = 0; i < Convert.ToInt32(texpoint); i++)
            {
                Task task = new Task(() => TaskPhoneSet(Firm, Model, Quantity, Cost, Processor, RAM, Battery, PDF, Photo, Convert.ToInt32(texpoint)));
                task.Start();
                Trace.WriteLine(task + "start");
                tasks[i] = task;
            }
            Task.WaitAll(tasks);
            //Task.Run(()=>phoneServerData.PhonesSetAllData());
            phoneServerData.PhonesSetAllData();
        }

        private async void TaskPhoneSet(string firm, string model, string quantity, string cost, string processor, string rAM, string battery, byte[] pDF, byte[] photo, int count)
        {
              phoneServerData.PhonesSet(firm, model, quantity, cost, processor, rAM, battery, pDF, photo, count);
              Trace.WriteLine("PHONES SET");
        }

       
        public List<string> LoadComputers()
        {
            DisableData();
            return computersData.LoadComputers();
        }

        public List<ComputersSet> GetCompCollection()
        {
            return computersData.GetCompCollections();
        }
        public List<string> LoadTivis()
        {
            DisableData();
            return tiviServer.GetTivis();
        }

        public void TiviSet(string Firm, string Model, string Quantity, string Cost, string textpoint)
        {
            ClearContent();
            internetMarketDateEntities = new InternetMarketDateEntities();

            for (int i = 0; i < Convert.ToInt32(textpoint); i++)
            {
                tiviServer.TiviSet(Firm, Model, Quantity, Cost);
            }

        }

        

        public void ComputerSet(string Firm, string Model, string Quantity, string Cost, string Processor, string RAM, string VRAM, string Graphics, string textpoint)
        {
            ClearContent();
            
            for (int i = 0; i < Convert.ToInt32(textpoint); i++)
            {
                computersData.ComputerSet(Firm, Model, Quantity, Cost, Processor, RAM, VRAM, Graphics);
            }
        }

        public void TabletsSet(string name, string model, string proc, string ram, string gpu, string resolution, string battery, string textpoint)
        {
            ClearContent();
            internetMarketDateEntities = new InternetMarketDateEntities();
            for (int i=0; i<Convert.ToInt32(textpoint); i++)
            {
                tabletServer.SetTablet(name, model, proc, ram, gpu, resolution, battery);
            } 
        }

        public List<string> LoadTablets()
        {
            DisableData();
            return tabletServer.LoadTablets();
        }


        public void OrganizationSet(string organization)
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            var orgdata = new OrganizationSet
            {
                Name = organization
            };
            internetMarketDateEntities.OrganizationSetSet.Add(orgdata);
            internetMarketDateEntities.SaveChanges();
        }

        public void CountrySet(string country)
        {
            countryData.CountrySet(country);
        }

        public void City(string name, string countryname)
        {
            var citydata = new CityData
            {
                CountryName = countryname,
                Name = name
            };
            internetMarketDateEntities.CityDataSet.Add(citydata);
            internetMarketDateEntities.SaveChanges();
        }

        public List<string> GetCountry()
        {
            return countryData.GetCountry();
        }

        public string[] GetCity()
        {
            DisableData();
            cities = internetMarketDateEntities.CityDataSet.ToList();
            return cities.AsParallel().Select(x => x.Name).ToArray();
        }

        public void Oblast(string name, string countryname, string cityname)
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            var obastdata = new OblastDataSet
            {
                Country = countryname,
                City = cityname,
                Name = name
            };
            internetMarketDateEntities.OblastDataSetSet.Add(obastdata);
            internetMarketDateEntities.SaveChanges();
        }

        public void CPUSet(string Name, string Architecture, string Chastota, string cores, string keshl1, string keshl2,  string keshl3, string gpu, string ram, string tdp, int point)
        {
            for (int i = 0; i < point; i++)
            {
                CPU.SetCpu(Name, Architecture, Chastota, cores, keshl1, keshl2, keshl3, gpu, ram, tdp);
            }
        }

        public void GraphicsCardSet(string name, string cores, string GraphicsCore, string Herts, string vram, string voltage, int point, byte[] photoread, byte[] arrayread)
        {
            for (int i = 0; i< point; i++)
            {
                graphicsCard.SetGpu(name, cores, GraphicsCore, Herts, vram, voltage, photoread, arrayread);
            }
        }

        public List<string> GetLaptop()
        {
            return laptopData.GetLaptop();
        }
        public void LaptopSet(string name, string model, string proc, string ram, string vram, string gpu, string screen, string resolution, string battery, int point)
        {
            for (int i = 0; i < point; i++)
            {
                laptopData.LeptopSet(name, model, proc, ram, vram, gpu, screen, resolution, battery);
            }
        }

        public List<string> LoadCPU()
        {
            return CPU.GetCpu();
        }

        public List<string> LoadGPU()
        {
            DisableData();

            return graphicsCard.GetGraphics();
        }

        public void setLogin(string name, string password)
        {
            UserSet user = new UserSet
            {
                Name = name,
                Password = password
            };
            internetMarketDateEntities.UserSet.Add(user);
            internetMarketDateEntities.SaveChanges();
        }

        private void ClearContent()
        {
            if (users != null) users.Clear();
            users = null;
            if (cpu != null) cpu.Clear();
            cpu = null;
        }

        public void SetMail(string mail)
        {
            mailData.SetMail(mail);
        }

        public List<string> GetMail()
        {
            return mailData.GetMails();
        }

        public void SetServer(string[] server)
        {
            if (server == null) return;
            mailData.SetMailServer(server);
        }

        public List<string> GetServers()
        {
            return mailData.GetServers();
        }
        public void SetBoiler(string Name, string Model, string Volume, string Voltage, string Power, string Cost)
        {
            boilerServer.BoilersSet(Name, Model, Volume, Voltage, Power, Cost);
        }

        public List<string> GetBoilersData()
        {
            return boilerServer.GetBoilers();
        }

        public void RemoveTivis(int start, int end)
        {
            tiviServer.RemoveTivis(start, end);
        }

        public void RemovePhones(int start, int stop)
        {
            phoneServerData.Remove(start, stop);
        }

        public void RemoveComputers(int start, int stop)
        {
            computersData.Remove(start, stop);
        }

        public void RemoveTablets(int start, int end)
        {
            tabletServer.Remove(start, end);
        }

        private void DisableData()
        {
            if(phoneServerData != null)phoneServerData.Disable();
            if (computersData != null)computersData.Disable();
            if (tiviServer != null) tiviServer.Disable();
            if (tabletServer != null) tabletServer.Disable();
            if (laptopData != null) laptopData.Dispose();
            if (mailData != null) mailData.Dispose();
            Trace.WriteLine("------->Disable<------");
        }
        public void Dispose()
        {
            if (internetMarketDateEntities != null) internetMarketDateEntities.Dispose();
            internetMarketDateEntities = null;
            if (users != null) users.Clear();
            users = null;
            cpu = null;
            phoneServerData.Dispose();
            userServer.Dispose();
            computersData.Dispose();
            tabletServer.Dispose();
            Trace.WriteLine("SERVER DISPOSE");
        }
    }

}
