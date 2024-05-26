using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManagerApi.Data.Repositories
{
    public class InvestmentRepository : Repository<Investment>, IInvestmentRepository
    {
        private static List<string> includeProperties = new() { nameof(Investment.Wallet), $"{nameof(Investment.Wallet)}.{nameof(Investment.Wallet.Currency)}", nameof(Investment.Etf) };

        public InvestmentRepository(DbContext context) : base(context, includeProperties)
        {
        }

        public override async Task Save(Investment entity)
        {
            var investment = await this.DbSet
                .FirstOrDefaultAsync(i =>
                    i.WalletId == entity.WalletId &&
                    i.EtfId == entity.EtfId);

            if (investment == null)
            {
                this.Insert(entity);
            }
            else
            {
                entity.Id = investment.Id;
                entity.Quantity += investment.Quantity;
                await this.UpdateAsync(entity);
            }
        }

        public override IQueryable<Investment> PrepareGetAllQuery(string filter)
        {
            var baseQuery = base.PrepareGetAllQuery(filter);

            if (filter == null)
            {
                return baseQuery;
            }

            return baseQuery.Where(x =>
                x.Etf.Name.Contains(filter));
        }

        public async Task<IEnumerable<Investment>> GetAllUserInvestmentsAsync(Guid userId, int skipCount, int takeCount, string filter = null, bool isActive = true)
        {
            var query = this.PrepareGetAllQuery(filter).Where(i => i.Wallet.UserId == userId);

            return await SoftDeleteQueryFilter(query, isActive)
                            .Skip(skipCount)
                            .Take(takeCount)
                            .ToListAsync();
        }
    }
}
