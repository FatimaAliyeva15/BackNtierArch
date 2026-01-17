using AutoMapper;
using Business.Services.Abstracts;
using Business.Utilities.Concretes;
using Core.Business.Utilities.Exceptions;
using Core.Business.Utilities.Results.Abstracts;
using Core.Business.Utilities.Results.Concretes;
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

        public async Task<IResult> AddProduct(CreateProductDTO createProductDTO)
        {
            var product = _mapper.Map<Product>(createProductDTO);
            var existsProduct = await _unitOfWork.ProductRepository.Get(p => p.Name == createProductDTO.Name);
            if (existsProduct != null)
            {
                return new ErrorResult("Mehsul elave edildi");
            }
            product.CreatedAt = DateTime.UtcNow;
            await _unitOfWork.ProductRepository.AddAsync(product);
            var result = await _unitOfWork.SaveAsync();
            if(result == 0)
            {
                return new ErrorResult("Mehsul elave edilmedi");
            }
            return new SuccessResult("Mehsul elave edildi");

        }

        public async Task<IResult> DeleteProduct(Guid id)
        {
            var existsProduct = await _unitOfWork.ProductRepository.Get(p => p.Id == id);
            if (existsProduct == null)
            {
                throw new NotFoundException(ExceptionMessage.ProductNotFound);
            }

            _unitOfWork.ProductRepository.Delete(existsProduct);
            var result = await _unitOfWork.SaveAsync();
            if(result == 0)
            {
                return new ErrorResult("Mehsul siline bilmedi");
            }
            return new SuccessResult("Mehsul silindi");
        }

        public async Task<IDataResult<List<GetAllProductsDTO>>> GetAllProducts()
        {

            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            if (products.Count == 0)
            {
                return new ErrorDataResult<List<GetAllProductsDTO>>(_mapper.Map<List<GetAllProductsDTO>>(products), "Mehsullar tapilmadi");
            }
            return new SuccessDataResult<List<GetAllProductsDTO>>(_mapper.Map<List<GetAllProductsDTO>>(products), "Mehsullar tapild;");
        }

        public async Task<IDataResult<GetProductDTO>> GetProductById(Guid id)
        {
            var existsProduct = await _unitOfWork.ProductRepository.Get(p => p.Id == id);
            if(existsProduct == null)
            {
                return new ErrorDataResult<GetProductDTO>(_mapper.Map<GetProductDTO>(existsProduct), $"{id}`li mehsul tapilmadi");
            }
            return new SuccessDataResult<GetProductDTO>(_mapper.Map<GetProductDTO>(existsProduct), $"{id}`li mehsul tapildi");
        }
    }

}
