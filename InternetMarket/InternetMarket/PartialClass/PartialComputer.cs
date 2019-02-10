using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket
{
    public partial class ComputersSet
    {
        public override string ToString()
        {
            return $"{Firm}, {Model}, {Quantity}, {Cost}, {Processor}, {RAM}, {VRAM}, {Graphics}";
        }
    }
}
