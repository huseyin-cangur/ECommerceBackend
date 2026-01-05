

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.Entity;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CartController : ControllerBase
    {
        private readonly ECommerceContext _context;

        public CartController(ECommerceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<CartDTO>> GetCart()
        {
            return CartToDTO(await GetOrCreateCartAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToCart(int productId, int quantity)
        {
            var cart = await GetOrCreateCartAsync();
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            cart.AddItem(product, quantity);
            var result = await _context.SaveChangesAsync() > 0;

            if (result)
                return CreatedAtAction(nameof(GetCart), CartToDTO(cart));


            return BadRequest(new ProblemDetails { Title = "Ürün sepete eklenemedi." });
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveItemFromCart(int productId, int quantity)
        {
            var cart = await GetOrCreateCartAsync();
            cart.RemoveItem(productId, quantity);
            var result = await _context.SaveChangesAsync() > 0;

            if (result)
                return Ok(CartToDTO(cart));

            return BadRequest(new ProblemDetails { Title = "Silme işlemi başarısız." });
        }


        private async Task<Cart> GetOrCreateCartAsync()
        {



            var cart = await _context.Carts
              .Include(c => c.CartItems)
              .ThenInclude(ci => ci.Product)
              .Where(c => c.CustomerId == Request.Cookies["customerId"])
              .FirstOrDefaultAsync();

            if (cart == null)
            {
                var customerId = Guid.NewGuid().ToString();
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(30),
                    IsEssential = true,
                    HttpOnly = true
                };

                Response.Cookies.Append("customerId", customerId, cookieOptions);


                cart = new Cart
                {
                    CustomerId = customerId
                };

                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            return cart;
        }

        private CartDTO CartToDTO(Cart cart)
        {
            return new CartDTO
            {
                Id = cart.Id,
                CustomerId = cart.CustomerId,
                CartItems = cart.CartItems.Select(ci => new CartItemDTO
                {
                    ProductId = ci.Product.Id,
                    ProductName = ci.Product.Name,
                    ProductPrice = ci.Product.Price,
                    ProductImageUrl = ci.Product.ImageUrl,
                    Quantity = ci.Quantity
                }).ToList()
            };
        }
    }
}