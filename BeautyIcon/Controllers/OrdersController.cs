using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyIcon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyIcon.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Cart _cart;

        public OrdersController(IOrderRepository orderRepository, Cart cart)
        {
            _orderRepository = orderRepository;
            _cart = cart;
        }

        public IActionResult Checkout()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {

            _cart.CartItems = _cart.GetItems();

            if (_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _cart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Your products are on their way! Thank you for shopping at BeautyIcon";
            return View();
        }
    }
}
