using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webshop.Data;

public class ProductsController : Controller
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    // /Products
    public IActionResult Index()
    {
        var products = _context.Products
            .Include(p => p.ProductImages)
            .ToList();
        return View(products);
    }

    // OPTIONAL later:
    // public IActionResult Details(int id)
    public IActionResult ViewProduct(int id)
    {
        var product = _context.Products
            .Include(p => p.Stocks)
            .Include(p => p.ProductImages)
            .FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();

        return View(product);
    }
}
