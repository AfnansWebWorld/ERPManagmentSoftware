namespace ManagementSoftware.Models
{
    public class SaleInvoice
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
