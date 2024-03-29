﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CraneId { get; set; }

        public string CraneName { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public DateTime OnCreated { get; set; }
    }
}
