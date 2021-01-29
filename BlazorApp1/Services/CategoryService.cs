using BlazorApp1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public List<Category> GetCategories() => _dbContext.Categories.ToList();
        public Category GetCategory(int id) => _dbContext.Categories.FirstOrDefault(c => c.Id == id);
        public bool CreateCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateCategory(Category category)
        {
            var existingCategory = _dbContext.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCategory(int id)
        {
            var existingCategory = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory != null)
            {
                _dbContext.Categories.Remove(existingCategory);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
