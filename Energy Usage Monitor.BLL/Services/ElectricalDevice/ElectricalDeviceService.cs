namespace Energy_Usage_Monitor.BLL.Services.ElectricalDevice
{
    public class ElectricalDeviceService : IElectricalDeviceService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger <ElectricalDeviceService> _logger;

        public ElectricalDeviceService(IUnitOfWork unitOfWork, IMapper mapper,ILogger<ElectricalDeviceService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<DeviceToReturnDto>> GetAllDevicesAsync()
        {
            var devices = await _unitOfWork.Devices.GetAllAsync();
            return _mapper.Map<IEnumerable<DeviceToReturnDto>>(devices);
        }

        public async Task<DeviceToReturnDto> GetDeviceByIdAsync(int id)
        {
            var devices = await _unitOfWork.Devices.GetByIdAsync(id);

            if (devices == null) 
            {
                _logger.LogWarning("Device With ID {Id} Not Found",id);
                return null;
            }

            return _mapper.Map<DeviceToReturnDto>(devices);
        }

        public async Task<DeviceToReturnDto> CreateDeviceAsync(DeviceForCreationDto deviceDto)
        {
            var device = _mapper.Map<Entities.Devices.ElectricalDevice>(deviceDto);

            device.CreatedBy = "system";
            device.ModifiedBy = "system";
            device.CreatedOn = DateTime.UtcNow;
            device.ModifiedOn = DateTime.UtcNow;


            await _unitOfWork.Devices.AddAsync(device);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<DeviceToReturnDto>(device);
        }

        public async Task<bool> UpdateDevice(int id, DeviceForUpdateDto dto)
        {
            var existingDevice = await _unitOfWork.Devices.GetByIdAsync(id);

            if (existingDevice == null)
            {
                _logger.LogWarning("Device With ID {Id} Not Found",id);
                return false;
            }

            _mapper.Map(dto,existingDevice);

            
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteDevice(int id)
        {
            var device = await _unitOfWork.Devices.GetByIdAsync(id);
            if (device == null) 
            {
              return false;
            }

            _unitOfWork.Devices.Delete(device);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
