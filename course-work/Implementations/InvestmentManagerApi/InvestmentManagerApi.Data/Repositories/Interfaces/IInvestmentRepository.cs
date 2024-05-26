using InvestmentManagerApi.Data.Entities;

namespace InvestmentManagerApi.Data.Repositories.Interfaces
{
    public interface IInvestmentRepository : IRepository<Investment>
    {
        Task<IEnumerable<Investment>> GetAllUserInvestmentsAsync(Guid userId, int skipCount, int takeCount, string filter = null, bool isActive = true);
        Task<int> CountUserInvestmentsAsync(Guid userId, string filter);
    }
}