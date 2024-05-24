using InvestmentManagerApi.Business.Requests;
using InvestmentManagerApi.Business.Responses.User;

namespace InvestmentManagerApi.Business.Interfaces
{
    public interface IUserService
    {
        Task<GetUsersResponse> GetUsersAsync(int page);
        Task<UserResponse> GetUserAsync(Guid id);
        Task<UserResponse> CreateUserAsync(CreateUpdateUserRequest request);
        Task<UserResponse> UpdateUserAsync(Guid id, CreateUpdateUserRequest request);
        Task DeleteUserAsync(Guid id);
    }
}
