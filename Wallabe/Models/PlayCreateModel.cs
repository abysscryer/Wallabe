using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;

namespace Wallabe.Models
{
    public class PlayCreateModel
    {
        public string GameId { get; set; }

        public PlayStatus Status { get; set; }

        public PlayState State { get; set; }
    }
}
