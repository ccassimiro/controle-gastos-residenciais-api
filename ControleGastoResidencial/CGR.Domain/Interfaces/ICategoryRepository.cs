using CGR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateAsync(Category category);
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
