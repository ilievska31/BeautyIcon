using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyIcon.Models
{
    public class ProductRepository : IProductRepository

    {

        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public IEnumerable<Product> GetProducts
        {
            get {
                return _appDbContext.Products.Include(c => c.Category).Include(b=>b.Brand);
            }
            
        }

        public IEnumerable<Product> GetOnSale
        {
            get
            {
                return _appDbContext.Products.Where(p=>p.OnSale).Include(c => c.Category);
            }
        }

        public IEnumerable<Product> GetInStock
        {
            get
            {
                return _appDbContext.Products.Where(p => p.InStock).Include(c => c.Category);
            }
        }


        public Product GetProductById(int id)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.ProductId == id);
        }
    }
}
