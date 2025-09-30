namespace Energy_Usage_Monitor.Entities.Devices
{
    public class ElectricalDevice : BaseEntity
    {
        public required string Name { get; set; }
        public required string Type { get; set;}
        public double PowerRatingWatts { get; set; }
        public bool IsOn { get; set; }
        public DateTime? LastTurnOn { get; set; }   
        public ICollection<DeviceUsage> Usages {  get; set; } = new List<DeviceUsage>();
    }
}
