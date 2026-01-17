using Business.Services.Abstracts;
using Core.Business.Utilities.Results.Concretes;
using Entities.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _service.GetAllProducts();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await _service.GetProductById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDTO createProductDTO)
        {
            var result = await _service.AddProduct(createProductDTO);
            if(result.Success)
                return Ok(result);
            return BadRequest(new ErrorResult("Mehsul elave edilmedi"));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await _service.DeleteProduct(id);
            if (result.Success)
                return Ok(result);
            return NoContent();
        }
    }
}
