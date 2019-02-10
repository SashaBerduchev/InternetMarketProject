using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket
{
    public partial class GraphicsCard
    {
        public override string ToString()
        {
            return $"{Name}, {GraphicsCore},{Cores}, {Herts}, {VRAM}, {Voltage}";
        }
    }
}
