using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket
{
    public partial class CPU
    {
        public override string ToString()
        {
            return $"{Name}, {Architecture}, {Cores}, {Chastota}, {KESHL1}, {KESHL2}, {KESHL3}, {GPU}, {RAM}, {TDP}";
        }
    }
}
