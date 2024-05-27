using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManagerApi.Data.Repositories
{
    public class WalletRepository : Repository<Wallet>, IWalletRepository
    {
        private static List<string> includeProperties = new() { nameof(Wallet.User), nameof(Wallet.Currency) };

        public WalletRepository(DbContext context) : base(context, includeProperties)
        {
        }

        public async Task<IEnumerable<Wallet>> GetByUserIdAsync(Guid userId)
        {
            IQueryable<Wallet> query = this.PrepareGetAllQuery();

            return await SoftDeleteQueryFilter(query, true)
                .Where(w => w.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> HasSufficientFunds(Guid id, decimal amount)
        {
            var wallet = await this.GetByIdAsync(id);
            return amount >= wallet.Balance;
        }

        public async Task AddFundsAsync(Guid id, decimal amount, bool convertFromEuro = false)
        {
            var wallet = await this.GetByIdAsync(id);
            if (convertFromEuro)
            {
                amount *= wallet.Currency.ToEuroRate;
            }
            wallet.Balance += amount;
        }

        public async Task RemoveFundsAsync(Guid id, decimal amount, bool convertFromEuro = false)
        {
            var wallet = await this.GetByIdAsync(id);
            if (convertFromEuro)
            {
                amount *= wallet.Currency.ToEuroRate;
            }

            var newBalance = wallet.Balance - amount;
            if (newBalance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(newBalance), "Insufficient funds");
            }
            wallet.Balance = newBalance;
        }
    }
}
