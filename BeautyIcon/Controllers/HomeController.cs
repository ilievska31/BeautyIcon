using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyIcon.Models;
using BeautyIcon.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeautyIcon.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IProductRepository _productRepository;

        public HomeController(AppDbContext appDbContext, IProductRepository productRepository)
        {
            _appDbContext = appDbContext;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var productsListViewModel = new ProductsListViewModel
            {
                Products = _productRepository.GetOnSale,
                SortName = "Products on sale"
            };
            return View(productsListViewModel);
        }
    }
}
