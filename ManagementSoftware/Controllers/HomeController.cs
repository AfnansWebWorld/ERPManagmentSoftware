using System.Diagnostics;
using ManagementSoftware.Data;
using ManagementSoftware.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSoftware.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            // Total Sales This Month (sum of quantities from ClientOrders in current month)
            ViewBag.TotalSales = _context.ClientOrders
                .Where(x => x.OrderDate.Month == currentMonth && x.OrderDate.Year == currentYear)
                .Sum(x => (int?)x.Quantity) ?? 0;

            // Pending Orders (e.g., orders placed this month — you can later add a status field to filter)
            ViewBag.PendingOrders = _context.ClientOrders
                .Count(x => x.OrderDate.Month == currentMonth && x.OrderDate.Year == currentYear);

            // Total Stock (sum of all balances)
            ViewBag.TotalStock = _context.StockSummaries
                .Sum(x => (int?)(x.TotalIn - x.TotalOut)) ?? 0;

            // Production Orders (assumes you have ProductionOrders with OrderDate)
            ViewBag.ProductionOrders = _context.ProductionOrders
                .Count(x => x.OrderDate.Month == currentMonth && x.OrderDate.Year == currentYear);

            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Dashboard()
        {
            ViewBag.TotalSales = _context.SaleInvoices
                .Where(x => x.InvoiceDate.Month == DateTime.Now.Month)
                .Sum(x => x.TotalAmount);

            ViewBag.PendingOrders = _context.ClientOrders.Count();
            ViewBag.TotalStock = _context.StockSummaries
     .ToList() // force client-side
     .Sum(x => x.Balance);

            ViewBag.ProductionOrders = _context.ProductionOrders.Count();

            ViewBag.SalesMonths = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
            ViewBag.SalesData = new[] { 12000, 14000, 18000, 11000, 15000, 20000 };

            ViewBag.StockCategories = new[] { "Raw Material", "Finished Goods", "Packaging", "WIP" };
            ViewBag.StockData = new[] { 450, 320, 120, 80 };

            return View();
        }

    }
}
