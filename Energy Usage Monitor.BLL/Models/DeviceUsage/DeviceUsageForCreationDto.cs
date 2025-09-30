namespace Energy_Usage_Monitor.BLL.Models.DeviceUsage
{
    public class DeviceUsageForCreationDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now;
        public double EnergyConsumedKWh { get; set; }
        public double DurationHours { get; set; }
        public int ElectricalDeviceId { get; set; }
    }
}
