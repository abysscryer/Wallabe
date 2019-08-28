using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallabe.Domains
{
    public class Transaction
    {
        public string Id { get; set; }

        public string PlayerId { get; set; }

        public decimal BeforeAmount { get; set; }

        public decimal ApplyAmount { get; set; }

        public decimal AfterAmount { get; set; }

        public TransactionType Type { get; set; }

        public DateTime OnCreated { get; set; }

        public virtual Deposit Deposit { get; set; }

        public virtual Exchange Exchange { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual Withdraw Withdraw { get; set; }
    }
}
