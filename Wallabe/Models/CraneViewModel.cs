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

        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string ImagePath { get; set; }

        public int Waitings { get; set; }
    }
}
