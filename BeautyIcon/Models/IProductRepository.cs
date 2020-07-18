using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyIcon.Models
{
    public interface IProductRepository
    {

        

        IEnumerable<Product> GetProducts { get; }
        IEnumerable<Product> GetOnSale { get; }
        IEnumerable<Product> GetInStock { get; }
        Product GetProductById(int id);
        
    }
}
