using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManagerApi.Data.Repositories
{
    public class InvestmentRepository : Repository<Investment>, IInvestmentRepository
    {
        public InvestmentRepository(DbContext context) : base(context)
        {
        }
    }
}
