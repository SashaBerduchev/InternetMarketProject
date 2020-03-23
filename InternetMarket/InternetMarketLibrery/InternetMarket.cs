using InternetMarket;
using InternetMarket.SERVER;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InternetMarketLibrery
{
    public class InternetMarket : IContract
    {
        private PhoneServerData phoneServerData;
        private TiviServerData tiviServer;
        private UserServerData userServer;
        private TabletServer tabletServer;
        private BoilerServerData boilerServer;
        private ComputersData computers;
        private InternetMarketEntities internetMarketDateEntities;
        private List<string> users;
        private List<string> cpulist;
        private List<CPUSet> cpu;
        private List<CountrySet> countries;
        private List<CityDataSet> cities;
        private List<string> listgpu;
        private List<GraphicsCardSet> graphics;

        public InternetMarket()
        {
            internetMarketDateEntities = new InternetMarketEntities();
            phoneServerData = new PhoneServerData();
            tiviServer = new TiviServerData();
            userServer = new UserServerData();
            tabletServer = new TabletServer();
            boilerServer = new BoilerServerData();
            computers = new ComputersData();
            Trace.WriteLine(this);
            Trace.WriteLine("Service of server INITIALIZE");
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
            List<string> users = userServer.GetUsers();
            if (users != null)
            {
                return users;
            }
            return null;
        }
        public List<string> LoadPhones()
        {
            return phoneServerData.GetPhones();
        }


        public void PhonesSet(string Firm, string Model, string Quantity, string Cost, string Processor, string RAM, string Battery, string texpoint, byte[] PDF, byte[] Photo)
        {
            for (int i = 0; i < Convert.ToInt32(texpoint); i++)
            {
                phoneServerData.PhonesSet(Firm, Model, Quantity, Cost, Processor, RAM, Battery, PDF, Photo);
            }
        }

        public List<string> LoadComputers()
        {
            return computers.LoadComputers();
        }

        public List<string> LoadTivis()
        {
            return tiviServer.GetTivis();
        }

        public void TiviSet(string Firm, string Model, string Quantity, string Cost, string textpoint)
        {
            ClearContent();
            internetMarketDateEntities = new InternetMarketEntities();

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
                computers.ComputerSet(Firm, Model, Quantity, Cost, Processor, RAM, VRAM, Graphics);
            }
        }

        public void TabletsSet(string name, string model, string proc, string ram, string gpu, string resolution, string battery, string textpoint)
        {
            ClearContent();
            internetMarketDateEntities = new InternetMarketEntities();
            for (int i = 0; i < Convert.ToInt32(textpoint); i++)
            {
                tabletServer.SetServer(name, model, proc, ram, gpu, resolution, battery);
            }

        }

        public void OrganizationSet(string organization)
        {
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            var orgdata = new OrganizationSetSet
            {
                Name = organization
            };
            internetMarketDateEntities.OrganizationSetSet.Add(orgdata);
            internetMarketDateEntities.SaveChanges();
        }

        public void CountrySet(string country)
        {
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            var countrydata = new CountrySet
            {
                NameCountry = country
            };
            internetMarketDateEntities.CountrySet.Add(countrydata);
            internetMarketDateEntities.SaveChanges();
        }

        public void City(string name, string countryname)
        {
            var citydata = new CityDataSet
            {
                CountryName = countryname,
                Name = name
            };
            internetMarketDateEntities.CityDataSet.Add(citydata);
            internetMarketDateEntities.SaveChanges();
        }

        public string[] GetCountry()
        {
            countries = internetMarketDateEntities.CountrySet.ToList();
            return countries.Select(x => x.NameCountry).ToArray();
        }

        public string[] GetCity()
        {
            cities = internetMarketDateEntities.CityDataSet.ToList();
            return cities.AsParallel().Select(x => x.Name).ToArray();
        }

        public void Oblast(string name, string countryname, string cityname)
        {
            InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
            var obastdata = new OblastDataSetSet
            {
                Country = countryname,
                City = cityname,
                Name = name
            };
            internetMarketDateEntities.OblastDataSetSet.Add(obastdata);
            internetMarketDateEntities.SaveChanges();
        }

        public void CPUSet(string Name, string Architecture, string Chastota, string cores, string keshl1, string keshl2, string keshl3, string gpu, string ram, string tdp, int point)
        {
            for (int i = 0; i < point; i++)
            {
                InternetMarketEntities internetMarketDateEntities = new InternetMarketEntities();
                CPUSet cpudat = new CPUSet
                {
                    Name = Name,
                    Architecture = Architecture,
                    Chastota = Chastota,
                    Cores = cores,
                    GPU = gpu,
                    KESHL1 = keshl1,
                    KESHL2 = keshl2,
                    KESHL3 = keshl3,
                    RAM = ram,
                    TDP = tdp
                };
                internetMarketDateEntities.CPUSet.Add(cpudat);
                internetMarketDateEntities.SaveChanges();
            }
        }

        public void GraphicsCardSet(string name, string cores, string GraphicsCore, string Herts, string vram, string voltage, int point)
        {
            for (int i = 0; i < point; i++)
            {
                GraphicsCardSet graphics = new GraphicsCardSet
                {
                    Name = name,
                    Cores = cores,
                    GraphicsCore = GraphicsCore,
                    Herts = Herts,
                    Voltage = voltage,
                    VRAM = vram
                };
                internetMarketDateEntities.GraphicsCardSet.Add(graphics);
                internetMarketDateEntities.SaveChanges();
            }
        }


        public void LaptopSet(string name, string model, string proc, string ram, string vram, string gpu, string screen, string resolution, string battery, int point)
        {
            for (int i = 0; i < point; i++)
            {
                LaptopsSet laptops = new LaptopsSet
                {
                    Name = name,
                    Battery = battery,
                    GPU = gpu,
                    Model = model,
                    Procc = proc,
                    RAM = ram,
                    Resolution = resolution,
                    SCREEN = screen,
                    VRAM = vram
                };
                internetMarketDateEntities.LaptopsSet.Add(laptops);
                internetMarketDateEntities.SaveChanges();
            }
        }

        public List<string> LoadCPU()
        {
            ClearContent();
            cpu = internetMarketDateEntities.CPUSet.ToList();
            cpulist = cpu.AsParallel().Select(x => x.Name + " " + x.Architecture + " " + x.Chastota + " " + x.Cores + " " + x.GPU + " " + x.KESHL1 + " " + x.KESHL2 + " " + x.KESHL3 + " " + x.RAM + " " + x.TDP).ToList();
            return cpulist;
        }

        public List<string> LoadGPU()
        {
            graphics = internetMarketDateEntities.GraphicsCardSet.ToList();
            listgpu = graphics.AsParallel().Select(x => x.Name + " " + x.Herts + " " + x.Voltage + " " + x.VRAM + " " + x.GraphicsCore + " " + x.Cores).ToList();
            return listgpu;
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
            if (cpulist != null) cpulist.Clear();
            if (cpu != null) cpu.Clear();
            cpulist = null;
            cpu = null;
        }

        public void SetBoiler(string Name, string Model, string Volume, string Voltage, string Power, string Cost)
        {
            boilerServer.BoilersSet(Name, Model, Volume, Voltage, Power, Cost);
        }

        public List<string> GetBoilersData()
        {
            return boilerServer.GetBoilers();
        }
        public void Dispose()
        {
            if (internetMarketDateEntities != null) internetMarketDateEntities.Dispose();
            internetMarketDateEntities = null;
            if (users != null) users.Clear();
            users = null;
            if (cpulist != null) cpulist.Clear();
            if (cpu != null) cpu.Clear();
            cpulist = null;
            cpu = null;
            phoneServerData.Dispose();
            userServer.Dispose();
            computers.Dispose();
            Trace.WriteLine("SERVER DISPOSE");
        }
    }
}

