

namespace WebAPI.Entity
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}