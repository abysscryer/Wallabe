using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Domains
{
    public class Player
    {
        /// <summary>
        /// 아이디(유저 아아디)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 닉네임
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 프로필 이미지
        /// </summary>
        public string ImagePath { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<Record> Records { get; set; }

        public virtual ICollection<CraneRecord> CraneRecords { get; set; }
    }
}
