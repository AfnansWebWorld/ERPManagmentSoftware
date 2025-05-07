namespace ManagementSoftware.Models
{
    public class Ledger
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public DateTime Date { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}
