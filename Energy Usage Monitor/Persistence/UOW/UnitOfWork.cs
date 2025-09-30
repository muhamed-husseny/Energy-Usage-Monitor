namespace Energy_Usage_Monitor.Persistence.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EnergyUsageDbContext _context;

        private IGenaricRepository<ElectricalDevice> _devices;
        private IGenaricRepository<DeviceUsage> _usage;

        public UnitOfWork(EnergyUsageDbContext context)
        {
            _context = context;
        }
        public IGenaricRepository<ElectricalDevice> Devices =>
        _devices ??= new GenaricRepository<ElectricalDevice>(_context);

        public IGenaricRepository<DeviceUsage> Usage =>
        _usage ??= new GenaricRepository<DeviceUsage>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
