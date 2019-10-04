using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternetMarket
{
    class InterMarketService : IContract , IDisposable
    {
        private InternetMarketDateEntities internetMarketDateEntities;
        private List<string> users;
        private List<string> passstr;
        private List<string> cpulist;
        private List<CPU> cpu;

        public InterMarketService()
        {
            internetMarketDateEntities = new InternetMarketDateEntities();

            Trace.WriteLine(this);
            Trace.WriteLine("Server INITIALIZE");
        }
        public bool SetUserLogin(string login, string pass)
        {
            ClearContent();
            passstr = internetMarketDateEntities.UserSet.Where(x => x.Name.Contains(login)).Select(p => p.Password).ToList();
            if (passstr.Contains(pass))
            {
                UserSet users = new UserSet//2
                {
                    Name = login,//3
                    Password = pass//4
                };
                Trace.WriteLine(this);
                Trace.WriteLine(users);
                internetMarketDateEntities.UserSet.Add(users);
                Trace.WriteLine(internetMarketDateEntities);
                internetMarketDateEntities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<string> GetUsers()
        {
            ClearContent();
            users = new List<string>();
            try
            {
                users = internetMarketDateEntities.UserSet.Select(x => x.Name).ToList();
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return users;
        }
        public List<string> LoadPhones()
        {
             List<PhonesSet> phones;
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            phones = internetMarketDateEntities.PhonesSet.ToList();
            List<string> listphones = phones.AsParallel().Select(x => x.Firm + " " + x.Model + " " + x.Processor + " " + x.Quantity + " " + x.RAM + " " + x.Cost).ToList();
            return listphones;
        }

        
        public void PhonesSet(string Firm, string Model, string Quantity, string Cost, string Processor, string RAM, string Battery, string texpoint)
        {

            for (int i = 0; i < Convert.ToInt32(texpoint); i++)
            {
                var phonedat = new PhonesSet
                {
                    Battery = Battery,
                    Cost = Cost,
                    Firm = Firm,
                    Model = Model,
                    Processor = Processor,
                    Quantity = Quantity,
                    RAM = RAM
                };
                internetMarketDateEntities.PhonesSet.Add(phonedat);
                internetMarketDateEntities.SaveChanges();
            }
        }

        public List<string> LoadComputers()
        {
            List<string> computerslist;
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            List<ComputersSet> computers;
            computers = internetMarketDateEntities.ComputersSet.ToList();
            computerslist = computers.AsParallel().Select(x => x.Firm + " " + x.Model + " " + x.Processor + " " + x.Quantity + " " + x.RAM + " " + x.VRAM).ToList();
            return computerslist;
        }


        public void TiviSet(string Firm, string Model, string Quantity, string Cost, string textpoint)
        {
            ClearContent();
            internetMarketDateEntities = new InternetMarketDateEntities();

            for (int i = 0; i < Convert.ToInt32(textpoint); i++)
            {
                var dataset = new TivisetSet
                {
                    Cost = Cost,
                    Firm = Firm,
                    Model = Model,
                    Quantity = Quantity
                };
                internetMarketDateEntities.TivisetSet.Add(dataset);
                internetMarketDateEntities.SaveChanges();
            }

        }

        public void ComputerSet(string Firm, string Model, string Quantity, string Cost, string Processor, string RAM, string VRAM, string Graphics, string textpoint)
        {
            ClearContent();
            internetMarketDateEntities = new InternetMarketDateEntities();

            for (int i = 0; i < Convert.ToInt32(textpoint); i++)
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
                internetMarketDateEntities.ComputersSet.Add(computers);
                internetMarketDateEntities.SaveChanges();
            }
        }

        public void TabletsSet(string name, string model, string proc, string ram, string gpu, string resolution, string battery, string textpoint)
        {
            ClearContent();
            internetMarketDateEntities = new InternetMarketDateEntities();
            for (int i=0; i<Convert.ToInt32(textpoint); i++)
            {
                var tabletsdata = new TabletSet
                {
                    Name = name,
                    Model = model,
                    Processor = proc,
                    Battery = battery,
                    GPU = gpu,
                    RAM = ram,
                    Resolution = resolution
                };
                internetMarketDateEntities.TabletSetSet.Add(tabletsdata);
                internetMarketDateEntities.SaveChanges();
            }
            
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
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            var countrydata = new Country
            {
                NameCountry = country
            };
            internetMarketDateEntities.CountrySet.Add(countrydata);
            internetMarketDateEntities.SaveChanges();
        }

        public void City(string name, string countryname)
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            var citydata = new CityData
            {
                CountryName = countryname,
                Name = name
            };
            internetMarketDateEntities.CityDataSet.Add(citydata);
            internetMarketDateEntities.SaveChanges();
        }

        public string[] GetCountry()
        {
            List<Country> countries;
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            countries = internetMarketDateEntities.CountrySet.ToList();
            return countries.Select(x =>x.NameCountry ).ToArray();
        }

        public string[] GetCity()
        {
            List<CityData> cities;
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
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
                InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
                CPU cpudat = new CPU
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
            for (int i = 0; i< point; i++)
            {
                InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
                GraphicsCard graphics = new GraphicsCard
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
                InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
                Laptops laptops = new Laptops
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
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            cpu = internetMarketDateEntities.CPUSet.ToList();
            cpulist = cpu.AsParallel().Select(x => x.Name + " " + x.Architecture + " " + x.Chastota + " " + x.Cores + " " + x.GPU + " " + x.KESHL1 + " " + x.KESHL2 + " " + x.KESHL3 + " " + x.RAM + " " + x.TDP).ToList();
            return cpulist;
        }

        public List<string> LoadGPU()
        {
            List<string> listgpu;
            List<GraphicsCard> graphics;
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
            graphics = internetMarketDateEntities.GraphicsCardSet.ToList();
            listgpu = graphics.AsParallel().Select(x => x.Name + " " + x.Herts + " " + x.Voltage + " " + x.VRAM + " " + x.GraphicsCore + " " + x.Cores).ToList();
            return listgpu;
        }

        public void setLogin(string name, string password)
        {
            InternetMarketDateEntities internetMarketDateEntities = new InternetMarketDateEntities();
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
            if (passstr != null) passstr.Clear();
            passstr = null;
            if (cpulist != null) cpulist.Clear();
            if (cpu != null) cpu.Clear();
            cpulist = null;
            cpu = null;
        }
        public void Dispose()
        {
            if (internetMarketDateEntities != null) internetMarketDateEntities.Dispose();
            internetMarketDateEntities = null;
            if (users != null) users.Clear();
            users = null;
            if (passstr != null) passstr.Clear();
            passstr = null;
            if (cpulist != null) cpulist.Clear();
            if (cpu != null) cpu.Clear();
            cpulist = null;
            cpu = null;
        }
    }

}
