namespace Energy_Usage_Monitor.Persistence.Data.Configurations.Devices
{
    public class ElectricalDeviceConfiguration : IEntityTypeConfiguration<ElectricalDevice>
    {
        public void Configure(EntityTypeBuilder<ElectricalDevice> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10,10);
            builder.Property(D => D.Name).HasColumnType("Varchar(50)").IsRequired();
            builder.Property(D => D.Type).HasColumnType("Varchar(50)").IsRequired();
            builder.Property(D => D.PowerRatingWatts).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(D => D.IsOn).HasColumnType("bit").IsRequired();
            builder.Property(D => D.LastTurnOn).HasColumnType("datetime2");
            builder.Property(D => D.CreatedBy).HasColumnType("Varchar(50)").IsRequired();
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GETUTCDATE()").IsRequired(); 
            builder.Property(D => D.ModifiedBy).HasColumnType("Varchar(50)").HasDefaultValue("system").IsRequired();
            builder.Property(D => D.ModifiedOn).HasColumnType("datetime2").HasDefaultValueSql("GETUTCDATE()").IsRequired(); 
        }
    }
}
