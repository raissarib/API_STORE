using API_FARMACIA_PM.Repositories;
using API_FARMACIA_PM.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_FARMACIA_PM.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest productRequest)
        {
            try
            {
                var createdProduct = await _productRepository.CreateProduct(productRequest);
                return Ok( new { id = createdProduct.Id, Produto = createdProduct});
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar o produto: {ex.Message}");
            }
        }

        private Task<IActionResult> GetProduct()
        {
            throw new NotImplementedException();
        }
    }
}