using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;

namespace Wallabe.Models
{
    public class GameViewModel
    {
        public string Id { get; set; }

        public string PlayerName { get; set; }

        public string CraneId { get; set; }

        public string CraneName { get; set; }

        public string OrderId { get; set; }

        public PlayStatus Status { get; set; }

        public PlayState State { get; set; }

        public DateTime OnCreated { get; set; }

        public DateTime OnUpdated { get; set; }
    }
}
