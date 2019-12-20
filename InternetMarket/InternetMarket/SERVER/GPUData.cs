using InternetMarket.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.SERVER
{
    class GPUData
    {
        private InternetMarketDateEntities internetMarket;
        private List<GraphicsCard> graphics;
        public GPUData()
        {
            internetMarket = new InternetMarketDateEntities();
        }


        public void SetGpu(string namegpu, string cores, string gpucores, string herts, string vram, string voltage, byte[] photoload, byte[] arrayread)
        {
            var gpudata = new GraphicsCard
            {
                Name = namegpu,
                Cores = cores,
                GraphicsCore = gpucores,
                Herts = herts,
                VRAM = vram,
                Voltage = voltage,
                Photo = photoload,
                PDF = arrayread
            };
            internetMarket.GraphicsCardSet.Add(gpudata);
            internetMarket.SaveChanges();
        }

        public List<string> GetGraphics()
        {
            LoadingWindow loading = new LoadingWindow();
            loading.Show();
            internetMarket = new InternetMarketDateEntities();
            graphics = internetMarket.GraphicsCardSet.ToList();
            loading.Close();
            return graphics.Select(x => x.Name + ' ' + x.GraphicsCore + ' ' + x.Herts + ' ' + x.Cores + ' ' + x.VRAM + ' ' + x.Voltage + ' ' + x.Photo).ToList();
        }
    }
}
