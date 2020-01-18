using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace InternetMarket
{
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        List<string> GetUsers();
        [OperationContract]
        void TiviSet(string Firm, string Model, string Quantity, string Cost, string textpoint);
        [OperationContract]
        Task<List<string>> LoadPhones();
        [OperationContract]
        void ComputerSet(string Firm, string Model, string Quantity, string Cost, string Processor, string RAM, string VRAM, string Graphics, string textpoint);
        [OperationContract]
        void TabletsSet(string name, string model, string proc, string ram, string gpu, string resolution, string battery, string textpoint);
        [OperationContract]
        void OrganizationSet(string organization);
        [OperationContract]
        void CountrySet(string country);
        [OperationContract]
        void City(string name, string countryname);
        [OperationContract]
        string[] GetCountry();
        [OperationContract]
        string[] GetCity();
        [OperationContract]
        void Oblast(string name, string countryname, string cityname);
        [OperationContract]
        void CPUSet(string Name, string Architecture, string Chastota, string cores, string keshl1, string keshl2, string keshl3, string gpu, string ram, string tdp, int point);
        [OperationContract]
        void GraphicsCardSet(string name, string cores, string GraphicsCore, string Herts, string vram, string voltage, int point, byte[] photoread, byte[] arrayread);
        [OperationContract]
        void LaptopSet(string name, string model, string proc, string ram, string vram, string gpu, string screen, string resolution, string battery, int point);
        [OperationContract]
        List<string> LoadComputers();
        [OperationContract]
        List<string> LoadCPU();
        [OperationContract]
        List<string> LoadGPU();
        [OperationContract]
        void setLogin(string name, string password);
        [OperationContract]
        bool SetUserLogin(string login, string pass);
        [OperationContract]
        void PhonesSet(string Firm, string Model, string Quantity, string Cost, string Processor, string RAM, string Battery, string texpoint, byte[] PDF, byte[] Photo);
        [OperationContract]
        List<string> GetBoilersData();
        [OperationContract]
        void SetBoiler(string Name, string Model, string Volume, string Voltage, string Power, string Cost);
        [OperationContract]
        void RemoveTivis(int start, int end);
        [OperationContract]
        void RemovePhones(int start, int stop);
        [OperationContract]
        void RemoveComputers(int start, int stop);
        [OperationContract]
        void RemoveTablets(int start, int end);
        [OperationContract]
        List<string> GetLaptop();
    };
}
