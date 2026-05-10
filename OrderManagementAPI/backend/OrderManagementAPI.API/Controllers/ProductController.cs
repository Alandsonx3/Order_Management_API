using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.Application.DTOs.Request;
using OrderManagementAPI.Application.Interfaces.Services;

namespace OrderManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            var result = await _productService.GetProductsAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetProductAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequestDto request)
        {
            var result = await _productService.CreateProductAsync(request);

            return CreatedAtAction(
                nameof(GetById),
                new {id = result.Id},
                result
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductRequestDto request)
        {
            var result = await _productService.UpdateProductAsync(request);

            if(result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.RemoveProductAsync(id);

            if (!result) return NotFound();

            return NoContent();

        }
    }
}
