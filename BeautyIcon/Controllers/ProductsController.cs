using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyIcon.Models;
using BeautyIcon.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BeautyIcon.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOptionRepository _optionRepository;

        public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository, IOptionRepository optionRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _optionRepository = optionRepository;
        }

        public IActionResult Index()
        {
            var productsList = new ProductsListViewModel
            {
                Products = _productRepository.GetProducts,
                SortName = "All products"


            };
            return View(productsList);
        }

        public IActionResult IndexByCategory(int cid)
        {
            var productsList = new ProductsListViewModel
            {
                Products = _productRepository.GetProducts.Where(p => p.CategoryId == cid),
                SortName = _productRepository.GetProducts.FirstOrDefault(p => p.CategoryId == cid).Category.CategoryName


            };
            return View("Index",productsList);
        }
        public IActionResult IndexByBrand(int bid)
        {
            var productsList = new ProductsListViewModel
            {
                Products = _productRepository.GetProducts.Where(p => p.BrandId == bid),
                SortName = _productRepository.GetProducts.FirstOrDefault(p => p.BrandId == bid).Brand.BrandName


            };
            return View("Index", productsList);
        }



        public IActionResult Details(int id)
        {
            var productDetailsViewModel = new ProductDetailsViewModel {
                Product = _productRepository.GetProductById(id),
                Options = _optionRepository.GetOptionsByProduct(id)
            };
            
            return View(productDetailsViewModel);
        }
    }
}
