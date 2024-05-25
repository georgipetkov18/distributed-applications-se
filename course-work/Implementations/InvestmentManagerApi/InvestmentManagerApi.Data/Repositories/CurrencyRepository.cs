using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManagerApi.Data.Repositories
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<Currency> PrepareGetAllQuery(string filter)
        {
            var baseQuery = base.PrepareGetAllQuery(filter);

            if (filter == null)
            {
                return baseQuery;
            }

            return baseQuery.Where(x => 
                x.Name.Contains(filter) ||
                x.Code.Contains(filter));
        }
    }
}
