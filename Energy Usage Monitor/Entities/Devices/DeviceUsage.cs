namespace Energy_Usage_Monitor.Entities.Devices
{
    public class DeviceUsage
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now;
        public double EnergyConsumedKWh { get; set; }
        public int ElectricalDeviceId { get; set; }
        public ElectricalDevice ElectricalDevice { get; set; } = null!;
        public double DurationHours => (EndTime - StartTime).TotalHours;
    }
}
