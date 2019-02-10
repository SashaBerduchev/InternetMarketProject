using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket
{
    public partial class CityData
    {
        public override string ToString()
        {
            return $"{Name}, {CountryName}";
        }
    }
}
