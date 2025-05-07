using ClosedXML.Excel;
using ManagementSoftware.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSoftware.Controllers
{
    [Authorize]
    public class ExportController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ExportController(ApplicationDbContext context) => _context = context;
        public IActionResult ExportLedgerToExcel()
        {
            
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Ledger Report");

            worksheet.Cell(1, 1).Value = "Account Name";
            worksheet.Cell(1, 2).Value = "Date";
            worksheet.Cell(1, 3).Value = "Debit";
            worksheet.Cell(1, 4).Value = "Credit";

            var data = _context.Ledgers.ToList();
            int row = 2;
            foreach (var item in data)
            {
                worksheet.Cell(row, 1).Value = item.AccountName;
                worksheet.Cell(row, 2).Value = item.Date.ToShortDateString();
                worksheet.Cell(row, 3).Value = item.Debit;
                worksheet.Cell(row, 4).Value = item.Credit;
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "LedgerReport.xlsx");
        }

        public IActionResult ProductionOrderToExcel()
        {
            var productionOrders = _context.ProductionOrders.ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ProductionOrders");

                // Header row
                worksheet.Cell(1, 1).Value = "Product Name";
                worksheet.Cell(1, 2).Value = "Order Date";
                worksheet.Cell(1, 3).Value = "Quantity";

                // Data rows
                for (int i = 0; i < productionOrders.Count; i++)
                {
                    var order = productionOrders[i];
                    worksheet.Cell(i + 2, 1).Value = order.ProductName;
                    worksheet.Cell(i + 2, 2).Value = order.OrderDate.ToShortDateString();
                    worksheet.Cell(i + 2, 3).Value = order.Quantity;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;

                    return File(
                        stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "ProductionOrders.xlsx"
                    );
                }
            }
        }

        public IActionResult LedgerToExcel()
        {
            var data = _context.Ledgers.ToList();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Ledger");

            // Headers
            worksheet.Cell(1, 1).Value = "Account Name";
            worksheet.Cell(1, 2).Value = "Date";
            worksheet.Cell(1, 3).Value = "Debit";
            worksheet.Cell(1, 4).Value = "Credit";

            // Content
            int row = 2;
            foreach (var entry in data)
            {
                worksheet.Cell(row, 1).Value = entry.AccountName;
                worksheet.Cell(row, 2).Value = entry.Date.ToString("yyyy-MM-dd");
                worksheet.Cell(row, 3).Value = entry.Debit;
                worksheet.Cell(row, 4).Value = entry.Credit;
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Ledger.xlsx");
        }
        public IActionResult ItemLedgerToExcel()
        {
            var data = _context.ItemLedgers.ToList();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("ItemLedgers");

            // Headers
            worksheet.Cell(1, 1).Value = "Item Name";
            worksheet.Cell(1, 2).Value = "Transaction Date";
            worksheet.Cell(1, 3).Value = "Quantity";
            worksheet.Cell(1, 4).Value = "Transaction Type";

            // Content
            int row = 2;
            foreach (var entry in data)
            {
                worksheet.Cell(row, 1).Value = entry.ItemName;
                worksheet.Cell(row, 2).Value = entry.TransactionDate.ToString("yyyy-MM-dd");
                worksheet.Cell(row, 3).Value = entry.Quantity;
                worksheet.Cell(row, 4).Value = entry.TransactionType;
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "ItemLedgers.xlsx");
        }
        public IActionResult StockSummaryToExcel()
        {
            var data = _context.StockSummaries.ToList();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("ItemLedgers");

            // Headers
            worksheet.Cell(1, 1).Value = "Item Name";
            worksheet.Cell(1, 2).Value = "Total In";
            worksheet.Cell(1, 3).Value = "Total Out";
            worksheet.Cell(1, 4).Value = "Balance";

            // Content
            int row = 2;
            foreach (var entry in data)
            {
                worksheet.Cell(row, 1).Value = entry.ItemName;
                worksheet.Cell(row, 2).Value = entry.TotalIn;
                worksheet.Cell(row, 3).Value = entry.TotalOut;
                worksheet.Cell(row, 4).Value = entry.Balance;
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "StockSummary.xlsx");
        }

        public IActionResult RecipeToExcel()
        {
            var data = _context.Recipes.ToList();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Recipes");

            // Headers
            worksheet.Cell(1, 1).Value = "Product Name";
            worksheet.Cell(1, 2).Value = "Ingredient";
            worksheet.Cell(1, 3).Value = "Quantity";
           

            // Content
            int row = 2;
            foreach (var entry in data)
            {
                worksheet.Cell(row, 1).Value = entry.ProductName;
                worksheet.Cell(row, 2).Value = entry.Ingredient;
                worksheet.Cell(row, 3).Value = entry.Quantity;
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "StockSummary.xlsx");
        }
    }
}
