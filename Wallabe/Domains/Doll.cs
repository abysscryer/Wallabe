using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Domains
{
    public class Doll
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string ImagePath { get; set; }

        public DateTime OnCreated { get; set; }

        public string CraneId { get; set; }

        public virtual Crane Crane { get; set; }
    }
}
