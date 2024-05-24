using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManagerApi.Data.Repositories
{
    public class WalletRepository : Repository<Wallet>, IWalletRepository
    {
        private static List<string> includeProperties = new() { "User", "Currency" };

        public WalletRepository(DbContext context) : base(context, includeProperties)
        {
        }
    }
}
