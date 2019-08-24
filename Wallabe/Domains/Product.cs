using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Domains
{
    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CraneId { get; set; }

        public int Quantity { get; set; }

        public int Cash { get; set; }

        public DateTime OnCreated { get; set; }

        public Crane Crane { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
