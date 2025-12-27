using Microsoft.AspNetCore.Mvc;
using Webshop.Data;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class ProductsController: Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // DELETE (GET)
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

