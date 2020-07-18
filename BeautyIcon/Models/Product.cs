using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyIcon.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public String ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public String ImageUrl { get; set; }
        public String ExtraImageUrl { get; set; }
        public bool OnSale { get; set; }
        public bool InStock { get; set; }
        public String ProductDescription { get; set; }
        public List<Option> ProductOptions { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public String ProductIngredients { get; set; }
    }
}
