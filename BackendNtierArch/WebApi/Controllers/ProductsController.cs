using Business.Services.Abstracts;
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
            return Ok(await _service.GetAllProducts());
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            return Ok(await _service.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDTO createProductDTO)
        {
            await _service.AddProduct(createProductDTO);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _service.DeleteProduct(id);
            return NoContent();
        }
    }
}
