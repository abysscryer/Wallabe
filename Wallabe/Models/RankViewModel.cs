using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Models
{
    public class RankViewModel
    {
        public string PlayerId { get; set; }

        public int Try { get; set; }

        public int Hit { get; set; }

        public float Rate { get; set; }
    }
}
