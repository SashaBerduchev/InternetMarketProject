using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarketMongoClient
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        void GetPhones();

        [OperationContract]
        void SetPhones(string name, string model, int cost, string processor, string battery, int point);

        [OperationContract]

        List<string> GetList();
    }
}
