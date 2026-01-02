

namespace WebAPI.Entity
{
    public class Cart
    {
        public int Id { get; set; }
        public string CustomerId { get; set; } = null!;
        public List<CartItem> CartItems { get; set; } = new();

       public void AddItem(Product product, int quantity)
        {
            var existingItem = CartItems.FirstOrDefault(item => item.ProductId == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                CartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }  

         public void RemoveItem(int productId, int quantity)
          {
                var itemToRemove = CartItems.FirstOrDefault(item => item.ProductId == productId);
                if (itemToRemove != null)
                {
                    itemToRemove.Quantity -= quantity;
                    if (itemToRemove.Quantity <= 0)
                    {
                        CartItems.Remove(itemToRemove);
                    }
                }
          } 


    }
}