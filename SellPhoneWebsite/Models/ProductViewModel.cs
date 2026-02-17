using SellPhoneWebsite.Models.Entities;
using X.PagedList;

namespace SellPhoneWebsite.Models
{
    public class ProductViewModel
    {
        public IPagedList<Product> ? Products { get; set; }
        public IEnumerable<Category> ? Categories { get; set; }
    }
}
