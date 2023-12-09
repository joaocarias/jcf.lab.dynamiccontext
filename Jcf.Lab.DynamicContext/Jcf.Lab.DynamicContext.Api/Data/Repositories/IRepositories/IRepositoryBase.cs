namespace Jcf.Lab.DynamicContext.Api.Data.Repositories.IRepositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T?> CreateAsync(T entity);
        Task<T?> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
