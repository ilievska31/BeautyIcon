using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using BeautyIcon.Models;
using BeautyIcon.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyIcon.Controllers
{
    [Authorize]
    public class CartsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly Cart _cart;

        public CartsController(IProductRepository productRepository, Cart cart)
        {
            _productRepository = productRepository;
            _cart = cart;
        }

        public IActionResult Index()
        {
            _cart.CartItems = _cart.GetItems();

            var cartViewModel = new CartViewModel
            {
                Cart = _cart,
                Total = _cart.GetTotal()
            }; 
            
            return View(cartViewModel);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var selected = _productRepository.GetProductById(id);
            if (selected!=null)
            {
               _cart.AddToCart(selected, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int id)
        {
            var selected = _productRepository.GetProductById(id);
            if (selected != null)
            {
                _cart.RemoveFromCart(selected);
            }

            return RedirectToAction("Index");
        }

    }
}
