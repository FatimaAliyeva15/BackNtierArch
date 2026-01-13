using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstracts
{
    public interface IProductService
    {
        public Task<List<GetAllProductsDTO>> GetAllProducts();
        public Task<GetProductDTO> GetProductById(Guid id);
        public Task AddProduct(CreateProductDTO createProductDTO);
        public Task DeleteProduct(Guid id);
    }
}
