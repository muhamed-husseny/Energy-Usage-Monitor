namespace Energy_Usage_Monitor.Persistence.Repositories.Devices
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {
        private readonly EnergyUsageDbContext _context;
        private readonly DbSet<T> _dbset;

        public GenaricRepository(EnergyUsageDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int Id)
        {
            return await _dbset.FindAsync(Id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> Predicate)
        {
            return await _dbset.Where(Predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
             await _dbset.AddAsync(entity);
        }
        public async Task Update(T entity)
        {
            _dbset.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

    }
}
