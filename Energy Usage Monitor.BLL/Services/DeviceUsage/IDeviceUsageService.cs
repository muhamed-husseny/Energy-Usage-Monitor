namespace Energy_Usage_Monitor.BLL.Services.DeviceUsage
{
    public interface IDeviceUsageService
    {
        Task<IEnumerable<DeviceUsageToReturnDto>> GetAllUsagesByDeviceIdAsync(int deviceId);
        Task<DeviceUsageToReturnDto> GetUsageByIdAsync(int usageId);
        Task<DeviceUsageToReturnDto> CreateUsageAsync(DeviceUsageForCreationDto dto);
        Task<bool> DeleteUsageAsync(int Id);

    }
}
