namespace Energy_Usage_Monitor.BLL.Services.ElectricalDevice
{
    public interface IElectricalDeviceService
    {
        Task<IEnumerable<DeviceToReturnDto>> GetAllDevicesAsync();
        Task<DeviceToReturnDto> GetDeviceByIdAsync(int id);
        Task<DeviceToReturnDto> CreateDeviceAsync (DeviceForCreationDto deviceDto);
        Task<bool> UpdateDevice(int Id, DeviceForUpdateDto deviceDto);
        Task<bool> DeleteDevice(int Id);
    }
}
