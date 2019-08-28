using System;
using System.Collections.Generic;

namespace Wallabe.Domains
{
    public class Withdraw
    {
        public Withdraw()
        {
            WithdrawLogs = new HashSet<WithdrawLog>();
        }

        public string TransactionId { get; set; }

        public decimal Amount { get; set; }

        public MoneyType Type { get; set; }

        public WithdrawStatus Status { get; set; }

        public WithdrawState State { get; set; }

        public DateTime OnUpdated { get; set; }

        public virtual Transaction Transaction { get; set; }

        public virtual ICollection<WithdrawLog> WithdrawLogs { get; set; }
    }
}
