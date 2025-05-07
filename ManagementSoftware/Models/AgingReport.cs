namespace ManagementSoftware.Models
{
    public class AgingReport
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public decimal OutstandingAmount { get; set; }
        public int DaysDue { get; set; }
    }
}
