using SellPhoneWebsite.Models.Entities;

namespace SellPhoneWebsite.Models
{
    public class ProductHomePage
    {
        // chỉ lấy 8 sản phẩm mới nhất
        public IEnumerable<Product>? LatestproductList { get; set; }
        // chỉ lấy 8 sản phẩm bán chạy nhất
        public IEnumerable<Product>? BestSaleProduct { get; set; }
    }
}
