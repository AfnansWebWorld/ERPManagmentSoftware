namespace ManagementSoftware.Models
{
    public class SaleReturnInvoice
    {
        public int Id { get; set; }
        public int SaleInvoiceId { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Reason { get; set; }
    }
}
