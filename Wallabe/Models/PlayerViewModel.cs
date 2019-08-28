using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Models
{
    public class PlayerViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public decimal Cash { get; set; }

        public DateTime OnCreated { get; set; }

    }
}
