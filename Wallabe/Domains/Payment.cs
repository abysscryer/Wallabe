namespace Wallabe.Domains
{
    public class Payment
    {
        public string TransactionId { get; set; }

        public string OrderId { get; set; }

        public virtual Transaction Transaction { get; set; }

        public virtual Order Order { get; set; }
    }
}
