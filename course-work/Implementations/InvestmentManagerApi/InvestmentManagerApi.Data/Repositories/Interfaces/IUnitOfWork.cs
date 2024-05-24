using Microsoft.EntityFrameworkCore;

namespace InvestmentManagerApi.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        IEtfRepository Etfs { get; set; }

        ICurrencyRepository Currencies { get; set; }

        IInvestmentRepository Investments { get; set; }

        IUserRepository Users { get; set; }

        IWalletRepository Wallets { get; set; }

        Task<int> SaveChangesAsync();
    }
}
