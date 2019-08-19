using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Domains
{
    public class Game
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string CraneId { get; set; }

        public PlayStatus Status { get; set; }

        public bool State { get; set; }

        public DateTime OnCreated { get; set; }

        public DateTime OnUpdated { get; set; }
    }
}
