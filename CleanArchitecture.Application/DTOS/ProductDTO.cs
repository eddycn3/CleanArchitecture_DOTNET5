using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOS
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get;  set; }

        [Required(ErrorMessage = "Description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get;  set; }
        
        [Required(ErrorMessage ="Price is required")]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get;  set; }
        
        [Required(ErrorMessage ="Stock is required")]
        [DisplayName("Stock")]
        [Range(1,9999)]
        public int Stock { get;  set; }

        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string Image { get;  set; }
        
        [DisplayName("Categories")]
        public int CategoryId { get; private set; }
        
        public Category Category { get; private set; }
    }
}
