using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Domains
{
    /// <summary>
    /// 기록
    /// </summary>
    public class CraneRecord
    {
        public string Date { get; set; }

        public string CraneId { get; set; }

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

        public virtual Crane Crane { get; set; }

        public virtual Player Player { get; set; }
    }
}
