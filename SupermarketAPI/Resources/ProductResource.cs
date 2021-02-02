﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Resources
{
    public class ProductResource
    {
        public int _id { get; set; }
        public string Name { get; set; }
        public int QuantityInPackage { get; set; }
        public string UnitOfMeasurement { get; set; }
        public CategoryResource Category { get; set; }
    }
}
