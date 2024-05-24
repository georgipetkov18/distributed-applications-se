namespace InvestmentManagerApi.Data.Entities
{
    public class Wallet : BaseEntity
    {
        required public Guid UserId { get; set; }
        public User User { get; set; }

        required public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public IEnumerable<Investment> Investments { get; set; }

        public Wallet()
        {
            this.Investments = new List<Investment>();
        }
    }
}
