using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarketClient
{
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        void PhonesSet(string Firm, string Model, string Quantity, string Cost, string Processor, string RAM, string Battery, string textpoint);
        [OperationContract]
        void TiviSet(string Firm, string Model, string Quantity, string Cost, string textpoint);
        [OperationContract]
        List<string> LoadPhones();
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
        void GraphicsCardSet(string name, string cores, string GraphicsCore, string Herts, string vram, string voltage, int point);
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
    }
}
