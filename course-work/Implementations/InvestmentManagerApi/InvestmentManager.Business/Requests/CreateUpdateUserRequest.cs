using System.ComponentModel.DataAnnotations;

namespace InvestmentManagerApi.Business.Requests
{
    public class CreateUpdateUserRequest
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
    }
}
