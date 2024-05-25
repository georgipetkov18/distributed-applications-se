using System.ComponentModel.DataAnnotations;

namespace InvestmentManagerApi.Business.Requests
{
    public class AuthRequest
    {
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }
    }
}
