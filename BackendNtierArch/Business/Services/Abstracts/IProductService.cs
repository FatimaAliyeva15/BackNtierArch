using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstracts
{
    public interface IProductService
    {
        public Task<List<GetProductDTO>> GetAllProductsAsync();
    }
}
