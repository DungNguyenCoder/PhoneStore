namespace SellPhoneWebsite.Models.Entities
{
    public class ProductImage
    {
        public int ID { get; set; }
        public string URL { get; set; } = null!;

        public int ProductID { get; set; }
        public Product? Product { get; set; }
    }
}
