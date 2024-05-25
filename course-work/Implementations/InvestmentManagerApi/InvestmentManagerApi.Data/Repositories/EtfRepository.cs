using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManagerApi.Data.Repositories
{
    public class EtfRepository : Repository<Etf>, IEtfRepository
    {
        public EtfRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<Etf> PrepareGetAllQuery(string filter)
        {
            var baseQuery = base.PrepareGetAllQuery(filter);

            if (filter == null)
            {
                return baseQuery;
            }

            return baseQuery.Where(x =>
                x.Name.Contains(filter));
        }
    }
}
