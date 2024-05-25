using InvestmentManagerApi.Business.Query;
using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.User;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface IUserService
    {
        Task<GetUsersResponse> GetUsersAsync(FilterParams parameters);
        Task<UserResponse> GetUserAsync(Guid id);
        Task<UserResponse> CreateUserAsync(CreateUpdateUserRequest request);
        Task<UserResponse> UpdateUserAsync(Guid id, CreateUpdateUserRequest request);
        Task DeleteUserAsync(Guid id);
    }
}
