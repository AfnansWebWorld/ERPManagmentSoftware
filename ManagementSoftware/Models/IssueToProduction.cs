namespace ManagementSoftware.Models
{
    public class IssueToProduction
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
