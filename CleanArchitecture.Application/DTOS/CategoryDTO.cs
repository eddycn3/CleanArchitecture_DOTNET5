using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOS
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
