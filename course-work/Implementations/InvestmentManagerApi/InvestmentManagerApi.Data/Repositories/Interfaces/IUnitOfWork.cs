using Microsoft.EntityFrameworkCore;

namespace InvestmentManagerApi.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        Task<int> SaveChangesAsync();
    }
}
