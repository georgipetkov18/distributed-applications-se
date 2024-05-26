namespace InvestmentManagerApi.Business.Responses.Auth
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
