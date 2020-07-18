using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyIcon.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories { get; }
    }
}
