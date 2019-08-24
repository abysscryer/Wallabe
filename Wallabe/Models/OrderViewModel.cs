using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Models
{
    public class OrderViewModel
    {
        public string Id { get; set; }

        public DateTime OnCreated { get; set; }

        public string PlayerName { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }
    }
}
