namespace Energy_Usage_Monitor.Persistence.Data
{
    public class EnergyUsageDbContext : DbContext
    {
        public EnergyUsageDbContext(DbContextOptions<EnergyUsageDbContext>options) : base(options) 
        {
        }

        public DbSet<ElectricalDevice> ElectricalDevices { get;set; }
        public DbSet<DeviceUsage> DeviceUsages { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EnergyUsageDbContext).Assembly);
        }

    }
}
