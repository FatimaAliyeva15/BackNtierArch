using Core.Business.Utilities.Results.Abstracts;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstracts
{
    public interface IProductService
    {
        public Task<IDataResult<List<GetAllProductsDTO>>> GetAllProducts();
        public Task<IDataResult<GetProductDTO>> GetProductById(Guid id);
        public Task<IResult> AddProduct(CreateProductDTO createProductDTO);
        public Task<IResult> DeleteProduct(Guid id);
    }
}
