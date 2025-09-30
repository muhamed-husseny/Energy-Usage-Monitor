namespace Energy_Usage_Monitor.Persistence.UOW
{
    public interface IUnitOfWork
    {
        IGenaricRepository<ElectricalDevice> Devices { get; }
        IGenaricRepository<DeviceUsage> Usage { get; }
        Task<int> SaveChangesAsync();
        
    }
}
