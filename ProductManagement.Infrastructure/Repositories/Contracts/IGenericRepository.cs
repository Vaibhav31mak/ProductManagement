namespace ProductManagement.Infrastructure.Repositories.Contracts;

/// <summary>
/// Generic Repository Contract.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IGenericRepository<T> where T : class, IEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
