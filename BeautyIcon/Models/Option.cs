using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyIcon.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public Product Product { get; set; }
        public String OptionName { get; set; }
        public String OptionImageUrl { get; set; }
    }
}
