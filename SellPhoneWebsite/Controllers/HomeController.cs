using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SellPhoneWebsite.Data;
using SellPhoneWebsite.Models;

namespace SellPhoneWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var res = new ProductHomePage();

            res.LatestproductList = await _context.Product.Include(p => p.Category).Include(p => p.ProductImages)
                .OrderByDescending(p => p.CreateAt)
                .Take(8)
                .ToListAsync();

            res.BestSaleProduct = await _context.Product.Include(p => p.Category).Include(p => p.ProductImages).Include(p => p.OrderItems)
                .OrderByDescending(p => p.OrderItems.Count())
                .Take(8)
                .ToListAsync();


            return View(res);
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
