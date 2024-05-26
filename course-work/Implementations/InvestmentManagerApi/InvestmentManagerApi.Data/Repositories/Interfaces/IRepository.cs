using InvestmentManagerApi.Data.Entities;

namespace InvestmentManagerApi.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(int skipCount, int takeCount, string filter = null, bool isActive = true);

        Task<T> GetByIdAsync(Guid id, bool isActive = true);

        Task<bool> ExistsAsync(Guid id, bool isActive = true);

        void Insert(T entity);

        Task UpdateAsync(T entity, string excludeProperties = "");

        Task ActivateDeactivate(T entity);

        Task ActivateDeactivate(int id);

        Task Save(T entity);

        Task<int> CountAsync(string filter);

        void Delete(T entity);

        void Delete(Guid id);

        IQueryable<T> PrepareGetAllQuery(string filter);
    }
}
