using ManagementSoftware.Data;
using ManagementSoftware.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSoftware.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

      

        // ItemLedger CRUD
        public IActionResult ItemLedger()
        {
            var items = _context.ItemLedgers.ToList();
            return View(items);
        }

        public IActionResult ItemLedgerDetails(int id)
        {
            var item = _context.ItemLedgers.Find(id);
            if (item == null)
                return NotFound();
            return View(item);
        }

        public IActionResult ItemLedgerCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ItemLedgerCreate(ItemLedger item)
        {
            if (ModelState.IsValid)
            {
                _context.ItemLedgers.Add(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(ItemLedger));
            }
            return View(item);
        }

        public IActionResult ItemLedgerEdit(int id)
        {
            var item = _context.ItemLedgers.Find(id);
            if (item == null)
                return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ItemLedgerEdit(int id, ItemLedger item)
        {
            if (id != item.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(ItemLedger));
            }
            return View(item);
        }

        public IActionResult ItemLedgerDelete(int id)
        {
            var item = _context.ItemLedgers.Find(id);
            if (item == null)
                return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("ItemLedgerDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult ItemLedgerDeleteConfirmed(int id)
        {
            var item = _context.ItemLedgers.Find(id);
            if (item != null)
            {
                _context.ItemLedgers.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(ItemLedger));
        }

        // StockSummary CRUD
        public IActionResult StockSummaryIndex()
        {
            var stocks = _context.StockSummaries.ToList();
            return View(stocks);
        }

        public IActionResult StockSummaryDetails(int id)
        {
            var stock = _context.StockSummaries.Find(id);
            if (stock == null)
                return NotFound();
            return View(stock);
        }

        public IActionResult StockSummaryCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StockSummaryCreate(StockSummary stock)
        {
            if (ModelState.IsValid)
            {
                _context.StockSummaries.Add(stock);
                _context.SaveChanges();
                return RedirectToAction(nameof(StockSummaryIndex));
            }
            return View(stock);
        }

        public IActionResult StockSummaryEdit(int id)
        {
            var stock = _context.StockSummaries.Find(id);
            if (stock == null)
                return NotFound();
            return View(stock);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StockSummaryEdit(int id, StockSummary stock)
        {
            if (id != stock.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(stock);
                _context.SaveChanges();
                return RedirectToAction(nameof(StockSummaryIndex));
            }
            return View(stock);
        }

        public IActionResult StockSummaryDelete(int id)
        {
            var stock = _context.StockSummaries.Find(id);
            if (stock == null)
                return NotFound();
            return View(stock);
        }

        [HttpPost, ActionName("StockSummaryDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult StockSummaryDeleteConfirmed(int id)
        {
            var stock = _context.StockSummaries.Find(id);
            if (stock != null)
            {
                _context.StockSummaries.Remove(stock);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(StockSummaryIndex));
        }
    }
}
