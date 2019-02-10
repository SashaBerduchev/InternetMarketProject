using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket
{
    public partial class CkladSet
    {
        public override string ToString()
        {
            return $"{Name}, {Type}, {Organisation},  {Oblast}, {City}, {Street}";
        }
    }
}
