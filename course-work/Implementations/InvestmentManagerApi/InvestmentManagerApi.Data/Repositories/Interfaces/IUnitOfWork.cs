using Microsoft.EntityFrameworkCore;

namespace InvestmentManagerApi.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        IEtfRepository Etfs { get; set; }
        ICurrencyRepository Currencies { get; set; }

        Task<int> SaveChangesAsync();
    }
}
