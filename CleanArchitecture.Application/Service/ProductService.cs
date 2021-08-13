using AutoMapper;
using CleanArchitecture.Application.DTOS;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository ??
                throw new ArgumentException(nameof(productRepository));
            _mapper = mapper;
        }


        public async Task<ProductDTO> GetById(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
           var products = await _productRepository.GetProductsAsync();
           return  _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        public async Task Add(ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);
            await _productRepository.CreateAsync(productEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity =  _productRepository.GetByIdAsync(id).Result;
            await _productRepository.RemoveAsync(productEntity);
        }

        public async Task Update(ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);
            await _productRepository.UpdateAsync(productEntity);
        }
    }
}
