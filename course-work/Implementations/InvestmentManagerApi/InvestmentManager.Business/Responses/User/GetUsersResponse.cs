namespace InvestmentManagerApi.Business.Responses.User
{
    public class GetUsersResponse : PagedResponse
    {
        public List<UserResponse> Users { get; set; }

    }
}
