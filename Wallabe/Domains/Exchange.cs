namespace Wallabe.Domains
{
    public class Exchange
    {
        public string TransactionId { get; set; }

        public string DollId { get; set; }

        public virtual Transaction Transaction { get; set; }

        public virtual Doll Doll { get; set; }
    }
}
