using AutoMapper;
using Business.Services.Abstracts;
using DataAccess.Repositories.Abstracts;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Concretes
{
    public class ProductService: IProductService
    {

        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetProductDTO>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<List<GetProductDTO>>(products);
        }

    }
}
