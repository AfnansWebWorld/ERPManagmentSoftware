namespace ManagementSoftware.Models
{
    public class ItemLedger
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; } // In/Out
    }
}
