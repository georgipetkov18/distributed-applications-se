namespace InvestmentManagerApi.Business.Requests
{
    public class PatchUserRequest
    {
        required public string FirstName { get; set; }
        required public string LastName { get; set; }
        required public string Email { get; set; }
        public int? Age { get; set; }
        public string? Password { get; set; }
    }
}
