namespace SellPhoneWebsite.Models.Entities
{
    public class OrderItem
    {
        public int ProductID { get; set; }
        public Product? Product { get; set; }

        public int OrderID { get; set; }
        public Order? Order { get; set; }

        public int Quantity { get; set; }
        public decimal SoldPrice { get; set; }
    }
}
