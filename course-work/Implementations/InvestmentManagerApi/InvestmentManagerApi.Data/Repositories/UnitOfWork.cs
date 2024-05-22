using InvestmentManagerApi.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManagerApi.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public DbContext Context 
        {
            get { return this.context; }
        }

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Dispose() => this.context?.Dispose();

        public async Task<int> SaveChangesAsync() => await this.context.SaveChangesAsync();
    }
}
