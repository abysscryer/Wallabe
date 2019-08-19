﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Domains
{
    public class Crane
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public PlayStatus Status { get; set; }

        public virtual ICollection<Doll> Dolls { get; set; }

        public virtual ICollection<Rank> Ranks { get; set; }
    }
}