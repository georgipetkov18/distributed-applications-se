using System.ComponentModel.DataAnnotations;

namespace InvestmentManagerClient.Models
{
    public class RegisterModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int? Age { get; set; }
        public Guid CurrencyId { get; set; }
        public decimal Balance { get; set; }
    }
}
