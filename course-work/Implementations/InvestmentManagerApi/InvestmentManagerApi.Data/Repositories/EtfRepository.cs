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
    }
}
