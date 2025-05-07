using ClosedXML.Excel;
using ManagementSoftware.Data;
using ManagementSoftware.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSoftware.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ----------- LEDGER -----------
        public IActionResult Ledger()
        {
            var ledgers = _context.Ledgers.ToList();
            return View(ledgers);
        }

        public IActionResult CreateLedger() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLedger(Ledger ledger)
        {
            if (ModelState.IsValid)
            {
                _context.Ledgers.Add(ledger);
                _context.SaveChanges();
                return RedirectToAction(nameof(Ledger));
            }
            return View(ledger);
        }

        public IActionResult EditLedger(int id)
        {
            var ledger = _context.Ledgers.Find(id);
            if (ledger == null) return NotFound();
            return View(ledger);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditLedger(int id, Ledger ledger)
        {
            if (id != ledger.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(ledger);
                _context.SaveChanges();
                return RedirectToAction(nameof(Ledger));
            }
            return View(ledger);
        }

        public IActionResult DeleteLedger(int id)
        {
            var ledger = _context.Ledgers.Find(id);
            if (ledger == null) return NotFound();
            return View(ledger);
        }

        [HttpPost, ActionName("DeleteLedger")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLedgerConfirmed(int id)
        {
            var ledger = _context.Ledgers.Find(id);
            if (ledger != null)
            {
                _context.Ledgers.Remove(ledger);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Ledger));
        }

        // ----------- AGING REPORT -----------
        public IActionResult AgingReports()
        {
            var reports = _context.AgingReports.ToList();
            return View(reports);
        }

        public IActionResult CreateAgingReport() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAgingReport(AgingReport report)
        {
            if (ModelState.IsValid)
            {
                _context.AgingReports.Add(report);
                _context.SaveChanges();
                return RedirectToAction(nameof(AgingReports));
            }
            return View(report);
        }

        public IActionResult EditAgingReport(int id)
        {
            var report = _context.AgingReports.Find(id);
            if (report == null) return NotFound();
            return View(report);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAgingReport(int id, AgingReport report)
        {
            if (id != report.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(report);
                _context.SaveChanges();
                return RedirectToAction(nameof(AgingReports));
            }
            return View(report);
        }

        public IActionResult DeleteAgingReport(int id)
        {
            var report = _context.AgingReports.Find(id);
            if (report == null) return NotFound();
            return View(report);
        }

        [HttpPost, ActionName("DeleteAgingReport")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAgingReportConfirmed(int id)
        {
            var report = _context.AgingReports.Find(id);
            if (report != null)
            {
                _context.AgingReports.Remove(report);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(AgingReports));
        }


       

    }
}
