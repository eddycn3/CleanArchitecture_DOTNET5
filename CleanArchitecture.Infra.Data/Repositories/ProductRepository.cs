using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            await _applicationDbContext.AddAsync(product);
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _applicationDbContext.FindAsync<Product>(id);
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _applicationDbContext
                .Products
                .Include(x => x.Category)
                .SingleOrDefaultAsync(p=> p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int? categoryId)
        {
            return await _applicationDbContext
                .Products
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _applicationDbContext.Remove(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _applicationDbContext.Update(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }
    }
}
