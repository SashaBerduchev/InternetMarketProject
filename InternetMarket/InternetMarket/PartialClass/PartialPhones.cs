﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket
{
    public partial class PhonesSet
    {
        public override string ToString()
        {
            return $"{Firm}, {Model}, {Quantity}, {Cost}, {Processor}, {RAM}, {Battery}, {Photo}, {PDF}";
        }
    }
}
