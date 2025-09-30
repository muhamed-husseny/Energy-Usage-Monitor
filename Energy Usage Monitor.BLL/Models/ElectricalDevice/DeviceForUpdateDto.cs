namespace Energy_Usage_Monitor.BLL.Models.ElectricalDevice
{
    public class DeviceForUpdateDto
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public double PowerRatingWatts { get; set; }
        public bool IsOn { get; set; }
    }
}
