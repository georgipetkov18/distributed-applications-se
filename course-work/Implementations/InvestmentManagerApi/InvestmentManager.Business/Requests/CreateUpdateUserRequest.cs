namespace InvestmentManagerApi.Business.Requests
{
    public class CreateUpdateUserRequest
    {
        required public string FirstName { get; set; }
        required public string LastName { get; set; }
        public int? Age { get; set; }
    }
}
