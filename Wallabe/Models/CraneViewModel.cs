using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;

namespace Wallabe.Models
{
    public class CraneViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public PlayStatus Status { get; set; }

        public string ImagePath { get; set; }
    }
}
