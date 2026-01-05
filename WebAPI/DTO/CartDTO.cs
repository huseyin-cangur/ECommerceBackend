

namespace WebAPI.DTO
{
    public class CartDTO
    {
        public int Id { get; set; }
        public string? CustomerId { get; set; } 
        public List<CartItemDTO> CartItems { get; set; } = new();
    }
}