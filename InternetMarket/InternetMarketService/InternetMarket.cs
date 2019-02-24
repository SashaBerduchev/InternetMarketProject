using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarketService
{
    public partial class InternetMarket : ServiceBase
    {
        private ServiceHost service_host = null;
        public InternetMarket()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (service_host != null) service_host.Close();

            string address_HTTP = "http://localhost:4000/InternetMarket";
            string address_TCP = "net.tcp://localhost:4000/InternetMarket";

            Uri[] address_base = { new Uri(address_HTTP), new Uri(address_TCP) };
            service_host = new ServiceHost(typeof(InternetMarketLibrery.InternetMarket), address_base);

            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            service_host.Description.Behaviors.Add(behavior);

            BasicHttpBinding binding_http = new BasicHttpBinding();
            service_host.AddServiceEndpoint(typeof(InternetMarketLibrery.IContract), binding_http, address_HTTP);
            service_host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            NetTcpBinding binding_tcp = new NetTcpBinding();
            binding_tcp.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            binding_tcp.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            service_host.AddServiceEndpoint(typeof(InternetMarketLibrery.IContract), binding_tcp, address_TCP);
            service_host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

            service_host.Open();

        }

        protected override void OnStop()
        {
            if (service_host != null)
            {
                service_host.Close();
                service_host = null;
            }
        }
    }
}
