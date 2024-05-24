using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManagerApi.Data.Repositories
{
    public class InvestmentRepository : Repository<Investment>, IInvestmentRepository
    {
        private static List<string> includeProperties = new() { nameof(Investment.Wallet), nameof(Investment.Etf) };

        public InvestmentRepository(DbContext context) : base(context, includeProperties)
        {
        }
    }
}
