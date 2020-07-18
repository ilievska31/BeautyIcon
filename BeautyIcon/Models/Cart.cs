using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyIcon.Models
{
    public class Cart
    {
        private readonly AppDbContext _appDbContext;

        public Cart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public String CartId { get; set; }
        public List<Item> CartItems { get; set; }
    
        
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            String cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new Cart(context)
            {
                CartId = cartId
            };
        }

        public void AddToCart(Product product, int quantity)
        {

            var cartItem = _appDbContext.Items.SingleOrDefault(p => p.Product.ProductId == product.ProductId && p.CartId == CartId);

            if (cartItem==null)
            {
                cartItem = new Item
                {
                    CartId = CartId,
                    Product = product,
                    Quantity = quantity
                };

                _appDbContext.Items.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Product product)
        {
            var cartItem = _appDbContext.Items.SingleOrDefault(p => p.Product.ProductId == product.ProductId && p.CartId == CartId);

            var lQuantity = 0;
            if (cartItem!=null)
            {
                if (cartItem.Quantity>0)
                {
                    cartItem.Quantity--;
                    lQuantity = cartItem.Quantity;
                }
                else
                {
                    _appDbContext.Items.Remove(cartItem);

                }
            }

            return lQuantity;
        }

        public List<Item> GetItems()
        {
            return CartItems ?? (CartItems = _appDbContext.Items.Where(i => i.CartId==CartId).Include(i=>i.Product).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext.Items.Where(i => i.CartId == CartId);
            _appDbContext.Items.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }

        public decimal GetTotal()
        {
            var total = _appDbContext.Items.Where(i => i.CartId == CartId).Select(i=>i.Product.ProductPrice*i.Quantity).Sum();
            return total;
        }
    
    
    }

}
