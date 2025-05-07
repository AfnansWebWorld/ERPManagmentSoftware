namespace ManagementSoftware.Models
{
    public class ProductionOrder
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }
}
