namespace InvestmentManagerApi.Data.Entities
{
    public class User : BaseEntity
    {
        required public string FirstName { get; set; }
        required public string LastName { get; set; }
        public int? Age { get; set; }

        public IEnumerable<Wallet> Wallets { get; set; }

        public User()
        {
            this.Wallets = new List<Wallet>();
        }
    }
}
