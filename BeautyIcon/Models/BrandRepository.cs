using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyIcon.Models
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _appDbContext;

        public BrandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Brand> GetBrands
        {
            get
            {
                return _appDbContext.Brands;
            }
        }
    }
}
