using System.ComponentModel.DataAnnotations;

namespace InvestmentManagerApi.Data.Entities
{
    public class Currency : BaseEntity 
    {
        [StringLength(maximumLength: 3, MinimumLength = 3)]
        required public string Code { get; set; }

        [MaxLength(50)]
        required public string Name { get; set; }
        required public decimal ToEuroRate { get; set; }

        public IEnumerable<Wallet> Wallets { get; set; }

        public Currency()
        {
            this.Wallets = new List<Wallet>();
        }
    }
}
