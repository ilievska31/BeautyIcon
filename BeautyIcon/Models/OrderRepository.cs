using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyIcon.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly Cart _cart;
        public OrderRepository(AppDbContext appDbContext, Cart cart)
        {
            _appDbContext = appDbContext;
            _cart = cart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _cart.GetTotal();

            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();


            var cartItems = _cart.GetItems();

            foreach(var i in cartItems)
            {
                var od = new OrderDetails
                {
                    Quantity = i.Quantity,
                    Price = i.Product.ProductPrice,
                    ProductId = i.Product.ProductId,
                    OrderId = order.OrderId

                };
                _appDbContext.OrderDetails.Add(od);
                
            }
            _appDbContext.SaveChanges();

        }
    }
}
