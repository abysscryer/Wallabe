﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Domains
{
    public class Game
    {
        public string Id { get; set; }

        public string PlayerId { get; set; }

        public string CraneId { get; set; }

        public PlayStatus Status { get; set; }

        public PlayState State { get; set; }

        public DateTime OnCreated { get; set; }

        public DateTime OnUpdated { get; set; }

        public virtual  Player Player { get; set; }

        public virtual Crane Crane { get; set; }

        public virtual ICollection<Play> Plays { get; set; }
    }
}
