using InvestmentManagerApi.Business.Responses.Auth;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> Authenticate(string email, string password);
    }
}
