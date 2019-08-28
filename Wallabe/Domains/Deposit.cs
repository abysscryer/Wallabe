namespace Wallabe.Domains
{
    public class Deposit
    {
        public string TransactionId { get; set; }

        public MoneyType Type { get; set; }

        public decimal Amount { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
