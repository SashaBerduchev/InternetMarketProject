using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket
{
    public partial class LaptopsSet
    {
        public override string ToString()
        {
          return  $"{Name}, {Model}, {Procc}, {RAM} {VRAM}, {GPU}, {SCREEN}, {Resolution}, {Battery} ";
        }
    }
}
