using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket
{
    public partial class TabletSetSet
    {
        public override string ToString()
        {
            return $"{Name}, {Model}, {Processor}, {RAM}, {GPU}, {Resolution}, {Battery}";
        }
    }
}
