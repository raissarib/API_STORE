using API_FARMACIA_PM.Repositories;
using API_FARMACIA_PM.Requests;
using Microsoft.AspNetCore.Mvc;

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
                return Ok(new { Produto = createdProduct });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar o produto: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await _productRepository.GetProduct(id);

                if (product is null)
                    return NotFound($"Produto com ID {id} não encontrado.");

                return Ok(new { Produto = product });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter o produto: {ex.Message}");
            }
        }

        [HttpGet("stock-product/{storeId}")]
        public async Task<IActionResult> GetProductsStore(int storeId)
        {
            try
            {
                var products = await _productRepository.GetProductsStore(storeId);

                if (products == null || !products.Any())
                    return NotFound($"Nenhum produto encontrado para a loja com ID {storeId}.");

                return Ok(new { Produtos = products });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter produtos por loja: {ex.Message}");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct(
            [FromBody] UpdateProductRequest updateProductRequest
        )
        {
            try
            {
                var updateProduct = await _productRepository.UpdateProduct(updateProductRequest);
                if (updateProduct is null)
                    return NotFound($"Produto com ID {updateProductRequest.Id} não encontrado.");
                return Ok(new { Produto = updateProduct });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar o produto: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _productRepository.DeleteProduct(id);

                if (product is null)
                    return NotFound($"Produto com ID {id} não encontrado.");

                return Ok(new { Produto = product });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao excluir o produto: {ex.Message}");
            }
        }
    }
}
