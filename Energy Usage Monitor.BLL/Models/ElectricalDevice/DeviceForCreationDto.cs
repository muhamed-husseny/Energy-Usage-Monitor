using System.ComponentModel.DataAnnotations;

namespace Energy_Usage_Monitor.BLL.Models.ElectricalDevice
{
    public class DeviceForCreationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Power rating must be greater than 0")]
        public double PowerRatingWatts { get; set; }

        [Required]
        public bool IsOn { get; set; }

    }
}
