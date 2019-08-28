using System;

namespace Wallabe.Domains
{
    public class WithdrawLog
    {
        public string Id { get; set; }

        public WithdrawStatus Status { get; set; }

        public WithdrawState State { get; set; }

        public DateTime OnCreated { get; set; }

        public string WithdrawId { get; set; }

        public Withdraw Withdraw { get; set; }
    }
}
