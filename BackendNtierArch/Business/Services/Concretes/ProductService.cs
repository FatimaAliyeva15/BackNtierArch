using AutoMapper;
using Business.Services.Abstracts;
using Business.Utilities.Concretes;
using Core.Business.Utilities.Exceptions;
using DataAccess.Repositories.Abstracts;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Concretes
{
    public class ProductService: IProductService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddProduct(CreateProductDTO createProductDTO)
        {
            var product = _mapper.Map<Product>(createProductDTO);
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProduct(Guid id)
        {
            var existsProduct = await _unitOfWork.ProductRepository.Get(p => p.Id == id);
            if (existsProduct == null)
            {
                throw new NotFoundException(ExceptionMessage.ProductNotFound);
            }

            _unitOfWork.ProductRepository.Delete(existsProduct);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<GetAllProductsDTO>> GetAllProducts()
        {

            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            return _mapper.Map<List<GetAllProductsDTO>>(products);
        }

        public async Task<GetProductDTO> GetProductById(Guid id)
        {
            var existsProduct = await _unitOfWork.ProductRepository.Get(p => p.Id == id);
            if(existsProduct == null)
            {
                throw new NotFoundException(ExceptionMessage.ProductNotFound);
            }
            
            return _mapper.Map<GetProductDTO>(existsProduct);
        }
    }



}
