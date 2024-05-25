using InvestmentManagerApi.Data.Entities;

namespace InvestmentManagerApi.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAndPasswordAsync(string email, string passwordHashed, bool isActive = true);
    }
}