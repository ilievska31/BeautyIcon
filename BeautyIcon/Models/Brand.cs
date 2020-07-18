using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyIcon.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public String BrandName { get; set; }
        public String BrandDescription { get; set; }
        public List<Product> Products { get; set; }
    }
}
