using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.Profilies
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<GetAllProductsDTO, Product>().ReverseMap();
            CreateMap<GetProductDTO, Product>().ReverseMap();
            CreateMap<CreateProductDTO, Product>();
        }
    }
}
