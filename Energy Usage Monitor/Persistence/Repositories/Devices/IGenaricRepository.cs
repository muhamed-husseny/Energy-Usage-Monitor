namespace Energy_Usage_Monitor.Persistence.Repositories.Devices
{
    public interface IGenaricRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int Id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T,bool>> Predicate);
        Task AddAsync(T entity);
        Task Update(T entity);
        void Delete(T entity);
    }
}
