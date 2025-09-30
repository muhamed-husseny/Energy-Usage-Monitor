namespace Energy_Usage_Monitor.BLL.Services.DeviceUsage
{
    public class DeviceUsageService : IDeviceUsageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeviceUsageService> _logger;
        public DeviceUsageService(IUnitOfWork unitOfWork , IMapper mapper,ILogger<DeviceUsageService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<DeviceUsageToReturnDto>> GetAllUsagesByDeviceIdAsync(int deviceId)
        {
            var usages = await _unitOfWork.Usage.FindAsync(u => u.ElectricalDeviceId == deviceId);

            if (!usages.Any())
            {
                _logger.LogWarning("No usages found for device ID {Id}", deviceId);
            }

            return _mapper.Map<IEnumerable<DeviceUsageToReturnDto>>(usages);
        }

        public async Task<DeviceUsageToReturnDto> GetUsageByIdAsync(int usageId)
        {
            var usage = await _unitOfWork.Usage.GetByIdAsync(usageId);

            if(usage == null)
            {
                _logger.LogWarning("Usage With ID {UsageId} Not Found",usageId);
                return null;
            }
            return _mapper.Map<DeviceUsageToReturnDto>(usage);
        }
        public async Task<DeviceUsageToReturnDto> CreateUsageAsync(DeviceUsageForCreationDto dto)
        {
            dto.DurationHours = (dto.EndTime - dto.StartTime).TotalHours;

            var device = await _unitOfWork.Devices.GetByIdAsync(dto.ElectricalDeviceId);
            if (device == null)
            {
                _logger.LogError("Device with ID {DeviceId} not found while creating usage.", dto.ElectricalDeviceId);
                throw new ArgumentException($"Device with ID {dto.ElectricalDeviceId} not found.");
            }

            dto.EnergyConsumedKWh = (device.PowerRatingWatts / 1000.0) * dto.DurationHours;

            var usageEntity = _mapper.Map<Entities.Devices.DeviceUsage>(dto);

            await _unitOfWork.Usage.AddAsync(usageEntity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<DeviceUsageToReturnDto>(usageEntity);
        }


        public async Task<bool> DeleteUsageAsync(int id)
        {
            try
            {
                var usage = await _unitOfWork.Usage.GetByIdAsync(id);
                if (usage == null) return false;

                _unitOfWork.Usage.Delete(usage);
                return await _unitOfWork.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting usage with ID {Id}", id);
                return false;
            }
        }

    }
}
