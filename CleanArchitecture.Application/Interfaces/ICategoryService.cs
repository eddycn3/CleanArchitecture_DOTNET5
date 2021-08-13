using CleanArchitecture.Application.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetById(int? id);
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task Add(CategoryDTO category);
        Task Remove(int? id);
        Task Update(CategoryDTO category);
    }
}
