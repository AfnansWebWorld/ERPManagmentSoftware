using ManagementSoftware.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManagementSoftware.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Ledger> Ledgers { get; set; }
        public DbSet<AgingReport> AgingReports { get; set; }
        public DbSet<ItemLedger> ItemLedgers { get; set; }
        public DbSet<StockSummary> StockSummaries { get; set; }
        public DbSet<PhysicalStock> PhysicalStocks { get; set; }
        public DbSet<DeliveryChallan> DeliveryChallans { get; set; }
        public DbSet<ClientOrder> ClientOrders { get; set; }
        public DbSet<SaleInvoice> SaleInvoices { get; set; }
        public DbSet<SaleReturnInvoice> SaleReturnInvoices { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<ProductionOrder> ProductionOrders { get; set; }
        public DbSet<IssueToProduction> IssueToProductions { get; set; }
        public DbSet<ReceivedFromProduction> ReceivedFromProductions { get; set; }
    }
}
