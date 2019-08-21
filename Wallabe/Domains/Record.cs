using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Domains
{
    public class Record
    {
        public string Date { get; set; }

        public string PlayerId { get; set; }

        /// <summary>
        /// 순위
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// 변동
        /// </summary>
        public int Shift { get; set; }

        public int Try { get; set; }

        public int Hit { get; set; }

        //[NotMapped]
        public float Rate { get; set; }

        public virtual Player Player { get; set; }
    }
}
