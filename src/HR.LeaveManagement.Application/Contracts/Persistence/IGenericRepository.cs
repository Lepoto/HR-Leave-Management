using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int Id);
    Task DeleteAsync(T entity);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);

}
