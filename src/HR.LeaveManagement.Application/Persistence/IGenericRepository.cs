namespace HR.LeaveManagement.Application.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int Id);
    Task<T> DeleteAsync(T entity);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);

}
