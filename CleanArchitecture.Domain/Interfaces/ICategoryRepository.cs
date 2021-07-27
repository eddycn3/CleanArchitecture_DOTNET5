using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategorysAsync();

        Task<Category> GetByIdAsync(int? id);

        Task<Category> CreateAsync(Category product);
        Task<Category> UpdateAsync(Category product);
        Task<Category> RemoveAsync(Category product);
    }
}
