namespace ManagementSoftware.Models
{
    public class StockSummary
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int TotalIn { get; set; }
        public int TotalOut { get; set; }
        public int Balance => TotalIn - TotalOut;
    }
}
