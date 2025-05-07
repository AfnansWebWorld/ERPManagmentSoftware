using ManagementSoftware.Data;
using ManagementSoftware.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSoftware.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // PhysicalStock CRUD
        public IActionResult PhysicalStock() => View(_context.PhysicalStocks.ToList());

        public IActionResult PhysicalStockDetails(int id)
        {
            var item = _context.PhysicalStocks.Find(id);
            return item == null ? NotFound() : View(item);
        }

        public IActionResult PhysicalStockCreate() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult PhysicalStockCreate(PhysicalStock item)
        {
            if (ModelState.IsValid)
            {
                _context.PhysicalStocks.Add(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(PhysicalStock));
            }
            return View(item);
        }

        public IActionResult PhysicalStockEdit(int id)
        {
            var item = _context.PhysicalStocks.Find(id);
            return item == null ? NotFound() : View(item);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult PhysicalStockEdit(int id, PhysicalStock item)
        {
            if (id != item.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(PhysicalStock));
            }
            return View(item);
        }

        public IActionResult PhysicalStockDelete(int id)
        {
            var item = _context.PhysicalStocks.Find(id);
            return item == null ? NotFound() : View(item);
        }

        [HttpPost, ActionName("PhysicalStockDelete"), ValidateAntiForgeryToken]
        public IActionResult PhysicalStockDeleteConfirmed(int id)
        {
            var item = _context.PhysicalStocks.Find(id);
            if (item != null)
            {
                _context.PhysicalStocks.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(PhysicalStock));
        }

        // DeliveryChallan CRUD
        public IActionResult DeliveryChallan() => View(_context.DeliveryChallans.ToList());

        public IActionResult DeliveryChallanDetails(int id)
        {
            var challan = _context.DeliveryChallans.Find(id);
            return challan == null ? NotFound() : View(challan);
        }

        public IActionResult DeliveryChallanCreate() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeliveryChallanCreate(DeliveryChallan challan)
        {
            if (ModelState.IsValid)
            {
                _context.DeliveryChallans.Add(challan);
                _context.SaveChanges();
                return RedirectToAction(nameof(DeliveryChallan));
            }
            return View(challan);
        }

        public IActionResult DeliveryChallanEdit(int id)
        {
            var challan = _context.DeliveryChallans.Find(id);
            return challan == null ? NotFound() : View(challan);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeliveryChallanEdit(int id, DeliveryChallan challan)
        {
            if (id != challan.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(challan);
                _context.SaveChanges();
                return RedirectToAction(nameof(DeliveryChallan));
            }
            return View(challan);
        }

        public IActionResult DeliveryChallanDelete(int id)
        {
            var challan = _context.DeliveryChallans.Find(id);
            return challan == null ? NotFound() : View(challan);
        }

        [HttpPost, ActionName("DeliveryChallanDelete"), ValidateAntiForgeryToken]
        public IActionResult DeliveryChallanDeleteConfirmed(int id)
        {
            var challan = _context.DeliveryChallans.Find(id);
            if (challan != null)
            {
                _context.DeliveryChallans.Remove(challan);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(DeliveryChallan));
        }

        // ClientOrder CRUD
        public IActionResult ClientOrder() => View(_context.ClientOrders.ToList());

        public IActionResult ClientOrderDetails(int id)
        {
            var item = _context.ClientOrders.Find(id);
            return item == null ? NotFound() : View(item);
        }

        public IActionResult ClientOrderCreate() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ClientOrderCreate(ClientOrder item)
        {
            if (ModelState.IsValid)
            {
                _context.ClientOrders.Add(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(ClientOrder));
            }
            return View(item);
        }

        public IActionResult ClientOrderEdit(int id)
        {
            var item = _context.ClientOrders.Find(id);
            return item == null ? NotFound() : View(item);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ClientOrderEdit(int id, ClientOrder item)
        {
            if (id != item.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(ClientOrder));
            }
            return View(item);
        }

        public IActionResult ClientOrderDelete(int id)
        {
            var item = _context.ClientOrders.Find(id);
            return item == null ? NotFound() : View(item);
        }

        [HttpPost, ActionName("ClientOrderDelete"), ValidateAntiForgeryToken]
        public IActionResult ClientOrderDeleteConfirmed(int id)
        {
            var item = _context.ClientOrders.Find(id);
            if (item != null)
            {
                _context.ClientOrders.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(ClientOrder));
        }

        // SaleInvoice CRUD
        public IActionResult SaleInvoice() => View(_context.SaleInvoices.ToList());

        public IActionResult SaleInvoiceDetails(int id)
        {
            var item = _context.SaleInvoices.Find(id);
            return item == null ? NotFound() : View(item);
        }

        public IActionResult SaleInvoiceCreate() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SaleInvoiceCreate(SaleInvoice item)
        {
            if (ModelState.IsValid)
            {
                _context.SaleInvoices.Add(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(SaleInvoice));
            }
            return View(item);
        }

        public IActionResult SaleInvoiceEdit(int id)
        {
            var item = _context.SaleInvoices.Find(id);
            return item == null ? NotFound() : View(item);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SaleInvoiceEdit(int id, SaleInvoice item)
        {
            if (id != item.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(SaleInvoice));
            }
            return View(item);
        }

        public IActionResult SaleInvoiceDelete(int id)
        {
            var item = _context.SaleInvoices.Find(id);
            return item == null ? NotFound() : View(item);
        }

        [HttpPost, ActionName("SaleInvoiceDelete"), ValidateAntiForgeryToken]
        public IActionResult SaleInvoiceDeleteConfirmed(int id)
        {
            var item = _context.SaleInvoices.Find(id);
            if (item != null)
            {
                _context.SaleInvoices.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(SaleInvoice));
        }

        // SaleReturnInvoice CRUD
        public IActionResult SaleReturnInvoice() => View(_context.SaleReturnInvoices.ToList());

        public IActionResult SaleReturnInvoiceDetails(int id)
        {
            var item = _context.SaleReturnInvoices.Find(id);
            return item == null ? NotFound() : View(item);
        }

        public IActionResult SaleReturnInvoiceCreate() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SaleReturnInvoiceCreate(SaleReturnInvoice item)
        {
            if (ModelState.IsValid)
            {
                _context.SaleReturnInvoices.Add(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(SaleReturnInvoice));
            }
            return View(item);
        }

        public IActionResult SaleReturnInvoiceEdit(int id)
        {
            var item = _context.SaleReturnInvoices.Find(id);
            return item == null ? NotFound() : View(item);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SaleReturnInvoiceEdit(int id, SaleReturnInvoice item)
        {
            if (id != item.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(SaleReturnInvoice));
            }
            return View(item);
        }

        public IActionResult SaleReturnInvoiceDelete(int id)
        {
            var item = _context.SaleReturnInvoices.Find(id);
            return item == null ? NotFound() : View(item);
        }

        [HttpPost, ActionName("SaleReturnInvoiceDelete"), ValidateAntiForgeryToken]
        public IActionResult SaleReturnInvoiceDeleteConfirmed(int id)
        {
            var item = _context.SaleReturnInvoices.Find(id);
            if (item != null)
            {
                _context.SaleReturnInvoices.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(SaleReturnInvoice));
        }

    }
}
