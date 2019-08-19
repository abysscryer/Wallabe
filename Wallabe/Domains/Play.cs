using System;

namespace Wallabe.Domains
{
    public class Play
    {
        public string Id { get; set; }

        public string GameId { get; set; }

        public PlayStatus Status { get; set; }

        public bool State { get; set; }

        public DateTime OnCreated { get; set; }
    }
}
