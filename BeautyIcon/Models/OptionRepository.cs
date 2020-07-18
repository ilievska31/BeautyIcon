using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyIcon.Models
{
    public class OptionRepository : IOptionRepository
    {
        private readonly AppDbContext _appDbContext;
        public OptionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Option> GetOptionsByProduct(int id)
        {
            return _appDbContext.Options.Where(o=>o.Product.ProductId==id); 
        }
    }
}
