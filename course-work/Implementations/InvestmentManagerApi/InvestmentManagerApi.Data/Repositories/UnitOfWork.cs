using InvestmentManagerApi.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManagerApi.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public IEtfRepository Etfs { get; set; }
        public ICurrencyRepository Currencies { get; set; }

        public DbContext Context 
        {
            get { return this.context; }
        }

        public UnitOfWork(DbContext context)
        {
            this.context = context;
            this.Etfs = new EtfRepository(context);
            this.Currencies = new CurrencyRepository(context);
        }

        public void Dispose() => this.context?.Dispose();

        public async Task<int> SaveChangesAsync() => await this.context.SaveChangesAsync();
    }
}
