using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Domains
{
    public class Order
    {
        public Order()
        {
            Games = new HashSet<Game>();
        }

        public string Id { get; set; }

        public DateTime OnCreated { get; set; }

        public string PlayerId { get; set; }

        public string ProductId { get; set; }

        public virtual Player Player { get; set; }

        public virtual Product Product { get; set; }

        public virtual ICollection<Game> Games { get; private set; }

        public virtual Payment Payment { get; set; }
    }
}
