namespace Energy_Usage_Monitor.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = "system";
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string ModifiedBy { get; set; } = "system";
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
    }
}
