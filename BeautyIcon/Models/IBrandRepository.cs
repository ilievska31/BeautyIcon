using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyIcon.Models
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetBrands { get; }
    }
}
