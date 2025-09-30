namespace Energy_Usage_Monitor.BLL.Models.DeviceUsage
{
    public class DeviceUsageToReturnDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ElectricalDeviceId { get; set; }
        public double EnergyConsumedKWh { get; set; }
        public double DurationHours { get; set; }

    }
}
