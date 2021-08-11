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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;     
        }
        public async Task<Category> CreateAsync(Category product)
        {
            await _applicationDbContext.AddAsync(product);
            return product;
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
           return await _applicationDbContext.FindAsync<Category>(id);
        }

        public async Task<IEnumerable<Category>> GetCategorysAsync()
        {
            return await _applicationDbContext.Categories.ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category product)
        {
            _applicationDbContext.Remove(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Category> UpdateAsync(Category product)
        {
            _applicationDbContext.Update(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }
    }
}
