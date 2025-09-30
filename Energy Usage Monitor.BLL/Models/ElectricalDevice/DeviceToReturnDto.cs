namespace Energy_Usage_Monitor.BLL.Models.ElectricalDevice
{
    public class DeviceToReturnDto
    {
        public int Id { get; set; }
        public required string Name { get; set; } 
        public required string Type { get; set; } 
        public double PowerRatingWatts { get; set; }
        public bool IsOn { get; set; }
        public DateTime? LastTurnOn { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
