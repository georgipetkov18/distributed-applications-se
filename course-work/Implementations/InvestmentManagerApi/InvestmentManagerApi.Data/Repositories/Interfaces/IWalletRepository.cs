using InvestmentManagerApi.Data.Entities;

namespace InvestmentManagerApi.Data.Repositories.Interfaces
{
    public interface IWalletRepository : IRepository<Wallet>
    {
        Task<IEnumerable<Wallet>> GetByUserIdAsync(Guid userId);
        Task<bool> HasSufficientFunds(Guid id, decimal amount);
        Task AddFundsAsync(Guid id, decimal amount);
        Task RemoveFundsAsync(Guid id, decimal amount);
    }
}