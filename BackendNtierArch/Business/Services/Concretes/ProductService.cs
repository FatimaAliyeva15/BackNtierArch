using AutoMapper;
using Business.Services.Abstracts;
using Business.Utilities.Concretes;
using Core.Business.Utilities.Exceptions;
using DataAccess.Repositories.Abstracts;
using Entities.Concrete;
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

        public async Task AddProduct(CreateProductDTO createProductDTO)
        {
            var product = _mapper.Map<Product>(createProductDTO);
            await _repository.AddAsync(product);
            await _repository.SaveAsync();
        }

        public async Task DeleteProduct(Guid id)
        {
            var existsProduct = await _repository.Get(p => p.Id == id);
            if (existsProduct == null)
            {
                throw new NotFoundException(ExceptionMessage.ProductNotFound);
            }

            _repository.Delete(existsProduct);
            await _repository.SaveAsync();
        }

        public async Task<List<GetAllProductsDTO>> GetAllProducts()
        {

            var products = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAllProductsDTO>>(products);
        }

        public async Task<GetProductDTO> GetProductById(Guid id)
        {
            var existsProduct = await _repository.Get(p => p.Id == id);
            if(existsProduct == null)
            {
                throw new NotFoundException(ExceptionMessage.ProductNotFound);
            }
            
            return _mapper.Map<GetProductDTO>(existsProduct);
        }
    }



}
