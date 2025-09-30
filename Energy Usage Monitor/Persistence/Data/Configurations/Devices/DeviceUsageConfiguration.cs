

namespace Energy_Usage_Monitor.Persistence.Data.Configurations.Devices
{
    internal class DeviceUsageConfiguration : IEntityTypeConfiguration<DeviceUsage>
    {
        public void Configure(EntityTypeBuilder<DeviceUsage> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10,10);
            builder.Property(D => D.StartTime).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()"); ;
            builder.Property(D => D.EndTime).HasDefaultValueSql("datetime2");
            builder.Property(D => D.EnergyConsumedKWh).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(D => D.ElectricalDeviceId).IsRequired();

        }
    }
}
