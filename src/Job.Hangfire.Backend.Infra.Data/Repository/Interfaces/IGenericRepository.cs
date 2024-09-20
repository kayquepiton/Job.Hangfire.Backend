using Job.Hangfire.Backend.Domain.Entities;

namespace Job.Hangfire.Backend.Infra.Data.Repository.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> CreateAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
    Task<IList<T>> GetAllAsync();
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteByIdAsync(Guid id);
}
