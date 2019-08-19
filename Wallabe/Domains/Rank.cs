using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Domains
{
    public class Rank
    {
        public string Date { get; set; }

        public string CraneId { get; set; }

        public string PlayerId { get; set; }

        public int Try { get; set; }

        public int Hit { get; set; }

        [NotMapped]
        public float Rate { get; set; }

        public virtual Crane Crane { get; set; }
    }
}
