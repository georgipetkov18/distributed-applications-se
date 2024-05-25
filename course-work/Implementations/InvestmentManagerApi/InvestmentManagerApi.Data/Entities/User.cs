using System.ComponentModel.DataAnnotations;

namespace InvestmentManagerApi.Data.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(70)]
        required public string FirstName { get; set; }

        [MaxLength(70)]
        required public string LastName { get; set; }

        [MaxLength(100)]
        required public string Email { get; set; }

        [MaxLength(255)]
        required public string Password { get; set; }

        public int? Age { get; set; }

        public IEnumerable<Wallet> Wallets { get; set; }

        public User()
        {
            this.Wallets = new List<Wallet>();
        }
    }
}
