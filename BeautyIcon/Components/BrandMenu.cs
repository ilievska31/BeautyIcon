using BeautyIcon.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyIcon.Components
{
    public class BrandMenu:ViewComponent
    {
        private readonly IBrandRepository _brandRepository;
        public BrandMenu(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IViewComponentResult Invoke()
        {
            var brands = _brandRepository.GetBrands.OrderBy(b => b.BrandName);

            return View(brands);
        }
    }
}
