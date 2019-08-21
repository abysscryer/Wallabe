using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;

namespace Wallabe.Models
{
    public class DollViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string ImaagePath { get; set; }

        public string CraneId { get; set; }

        /// <summary>
        /// 인형이 속한 크레인의 상태
        /// </summary>
        public PlayStatus Status { get; set; }
    }
}
