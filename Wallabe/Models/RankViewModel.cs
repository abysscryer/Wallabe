using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Models
{
    public class RankViewModel
    {
        public string Date { get; set; }
        /// <summary>
        /// 닉네임
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// 프로필 이미지 경로
        /// </summary>
        public string ImagePath { get; set; }

        public int Try { get; set; }

        public int Hit { get; set; }

        public float Rate { get; set; }

        public int Rank { get; set; }

        /// <summary>
        /// 변동
        /// </summary>
        public int Shift { get; set; }
    }
}
