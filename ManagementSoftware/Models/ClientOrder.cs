namespace ManagementSoftware.Models
{
    public class ClientOrder
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public DateTime OrderDate { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }
}
