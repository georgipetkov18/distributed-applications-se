namespace InvestmentManagerApi.Data.Entities
{
    public class Currency : BaseEntity 
    {
        required public string Code { get; set; }
        required public string Name { get; set; }
        required public decimal ToEuroRate { get; set; }

        public IEnumerable<Wallet> Wallets { get; set; }

        public Currency()
        {
            this.Wallets = new List<Wallet>();
        }
    }
}
