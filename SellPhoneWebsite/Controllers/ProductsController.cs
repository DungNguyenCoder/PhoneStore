using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SellPhoneWebsite.Data;
using SellPhoneWebsite.Models;
using System.Threading.Tasks;
using X.PagedList.Extensions;

namespace SellPhoneWebsite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(
          string? keyword,
          int? categoryId,
          decimal? priceMin,
          decimal? priceMax,
          string? sortOrder,
          int page = 1,
          int pageSize = 21)
        {
            var productList = _context.Product
                .Include(p => p.ProductImages).Include(p=>p.Category)
                .Where(p => p.Status == "Available")
                .AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                productList = productList.Where(p => p.Name.ToLower().Contains(keyword.ToLower()) || p.Category.Name.ToLower().Contains(keyword.ToLower()));
            }

            if (categoryId != null)
            {
                productList = productList.Where(p => p.CategoryID == categoryId);
            }

            if (priceMin.HasValue)
            {
                productList = productList.Where(p => p.Price >= priceMin.Value);
            }

            if (priceMax.HasValue)
            {
                productList = productList.Where(p => p.Price <= priceMax.Value);
            }

            switch (sortOrder)
            {
                case "price_asc":
                    productList = productList.OrderBy(p => p.Price);
                    break;

                case "price_desc":
                    productList = productList.OrderByDescending(p => p.Price);
                    break;

                default:
                    productList = productList.OrderByDescending(p => p.ID);
                    break;
            }

            ProductViewModel productViewModel = new ProductViewModel
            {
                Products = productList.ToPagedList(page, pageSize),
                Categories = await _context.Category.Include(c => c.Products).ToListAsync()
            };

            return View(productViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> ProductDetail(int id)
        {
            var product = await _context.Product.Include(p=>p.Category).Include(p=>p.ProductImages).FirstOrDefaultAsync(p => p.ID == id);
            if (product != null)
            {
                return View(product);
            }
            return NotFound();
        }
    }
}
