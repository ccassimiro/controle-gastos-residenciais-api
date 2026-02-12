using CGR.Domain.Entities;
using CGR.Domain.Interfaces;
using CGR.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGR.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _categoryContext;

        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }
        public async Task CreateAsync(Category category)
        {
            _categoryContext.Categories.Add(category);
            await _categoryContext.SaveChangesAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var category = await _categoryContext.Categories.FindAsync(id);
            if (category == null)
                throw new KeyNotFoundException($"Category with id '{id}' was not found.");

            return category;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryContext.Categories.ToListAsync();
        }
    }
}
