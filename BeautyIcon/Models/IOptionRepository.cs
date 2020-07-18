using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyIcon.Models
{
    public interface IOptionRepository 
    {
        IEnumerable<Option> GetOptionsByProduct(int id);
    }
}
