using BlazorApp1.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public List<Product> GetProducts() => _dbContext.Products.Include(u => u.Category).ToList();
        public Product GetProduct(int id) => _dbContext.Products.Include(u => u.Category).FirstOrDefault(c => c.Id == id);
        public List<Category> GetCategoryList() => _dbContext.Categories.ToList();
        public bool CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateProduct(Product product)
        {
            var existingProduct = _dbContext.Products.FirstOrDefault(c => c.Id == product.Id);
            if (existingProduct != null)
            {
                if(product.Image == null)
                {
                    product.Image = existingProduct.Image;
                }

                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteProduct(int id)
        {
            var existingProduct = _dbContext.Products.FirstOrDefault(c => c.Id == id);
            if (existingProduct != null)
            {
                _dbContext.Products.Remove(existingProduct);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
