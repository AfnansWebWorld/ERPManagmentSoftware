using ClosedXML.Excel;
using ManagementSoftware.Data;
using ManagementSoftware.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSoftware.Controllers
{
    [Authorize]
    public class ProductionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductionController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // Recipe CRUD
        public IActionResult Recipe()
        {
            return View(_context.Recipes.ToList());
        }

        public IActionResult RecipeDetails(int id)
        {
            var recipe = _context.Recipes.Find(id);
            if (recipe == null) return NotFound();
            return View(recipe);
        }

        public IActionResult RecipeCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RecipeCreate(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Recipes.Add(recipe);
                _context.SaveChanges();
                return RedirectToAction(nameof(Recipe));
            }
            return View(recipe);
        }

        public IActionResult RecipeEdit(int id)
        {
            var recipe = _context.Recipes.Find(id);
            if (recipe == null) return NotFound();
            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RecipeEdit(int id, Recipe recipe)
        {
            if (id != recipe.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(recipe);
                _context.SaveChanges();
                return RedirectToAction(nameof(Recipe));
            }
            return View(recipe);
        }

        public IActionResult RecipeDelete(int id)
        {
            var recipe = _context.Recipes.Find(id);
            if (recipe == null) return NotFound();
            return View(recipe);
        }

        [HttpPost, ActionName("RecipeDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult RecipeDeleteConfirmed(int id)
        {
            var recipe = _context.Recipes.Find(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Recipe));
        }

        // ProductionOrder CRUD

        public IActionResult ProductionOrder()
        {
            var orders = _context.ProductionOrders.ToList();
            if (orders == null || !orders.Any())
            {
                // Optionally, log or handle empty data scenario
                return View(new List<ProductionOrder>()); // Pass an empty list to avoid null reference
            }
            return View(orders);
        }


        public IActionResult ProductionOrderDetails(int id)
        {
            var order = _context.ProductionOrders.Find(id);
            if (order == null) return NotFound();
            return View(order);
        }

        public IActionResult ProductionOrderCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductionOrderCreate(ProductionOrder order)
        {
            if (ModelState.IsValid)
            {
                _context.ProductionOrders.Add(order);
                _context.SaveChanges();
                return RedirectToAction(nameof(ProductionOrder));
            }
            return View(order);
        }

        public IActionResult ProductionOrderEdit(int id)
        {
            var order = _context.ProductionOrders.Find(id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductionOrderEdit(int id, ProductionOrder order)
        {
            if (id != order.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(order);
                _context.SaveChanges();
                return RedirectToAction(nameof(ProductionOrder));
            }
            return View(order);
        }

        public IActionResult ProductionOrderDelete(int id)
        {
            var order = _context.ProductionOrders.Find(id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost, ActionName("ProductionOrderDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult ProductionOrderDeleteConfirmed(int id)
        {
            var order = _context.ProductionOrders.Find(id);
            if (order != null)
            {
                _context.ProductionOrders.Remove(order);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(ProductionOrder));
        }


        // IssueToProduction CRUD

        public IActionResult IssueToProduction()
        {
            var list = _context.IssueToProductions.ToList();
            return View(list);
        }

        public IActionResult IssueToProductionDetails(int id)
        {
            var issue = _context.IssueToProductions.Find(id);
            if (issue == null) return NotFound();
            return View(issue);
        }

        public IActionResult IssueToProductionCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IssueToProductionCreate(IssueToProduction model)
        {
            if (ModelState.IsValid)
            {
                _context.IssueToProductions.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(IssueToProduction));
            }
            return View(model);
        }

        public IActionResult IssueToProductionEdit(int id)
        {
            var issue = _context.IssueToProductions.Find(id);
            if (issue == null) return NotFound();
            return View(issue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IssueToProductionEdit(int id, IssueToProduction model)
        {
            if (id != model.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(IssueToProduction));
            }
            return View(model);
        }

        public IActionResult IssueToProductionDelete(int id)
        {
            var issue = _context.IssueToProductions.Find(id);
            if (issue == null) return NotFound();
            return View(issue);
        }

        [HttpPost, ActionName("IssueToProductionDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult IssueToProductionDeleteConfirmed(int id)
        {
            var issue = _context.IssueToProductions.Find(id);
            if (issue != null)
            {
                _context.IssueToProductions.Remove(issue);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(IssueToProduction));
        }

        // ReceivedFromProduction CRUD

        public IActionResult ReceivedFromProduction()
        {
            var data = _context.ReceivedFromProductions.ToList();
            return View(data);
        }

        public IActionResult ReceivedFromProductionDetails(int id)
        {
            var item = _context.ReceivedFromProductions.Find(id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult ReceivedFromProductionCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReceivedFromProductionCreate(ReceivedFromProduction model)
        {
            if (ModelState.IsValid)
            {
                _context.ReceivedFromProductions.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(ReceivedFromProduction));
            }
            return View(model);
        }

        public IActionResult ReceivedFromProductionEdit(int id)
        {
            var item = _context.ReceivedFromProductions.Find(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReceivedFromProductionEdit(int id, ReceivedFromProduction model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(ReceivedFromProduction));
            }
            return View(model);
        }

        public IActionResult ReceivedFromProductionDelete(int id)
        {
            var item = _context.ReceivedFromProductions.Find(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("ReceivedFromProductionDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult ReceivedFromProductionDeleteConfirmed(int id)
        {
            var item = _context.ReceivedFromProductions.Find(id);
            if (item != null)
            {
                _context.ReceivedFromProductions.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(ReceivedFromProduction));
        }



    }
}
