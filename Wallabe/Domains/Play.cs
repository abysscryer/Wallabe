using System;

namespace Wallabe.Domains
{
    public class Play
    {
        public string Id { get; set; }

        public string GameId { get; set; }

        public PlayStatus Status { get; set; }

        public PlayState State { get; set; }

        public DateTime OnCreated { get; set; }

        public Game Game { get; set; }
    }
}
