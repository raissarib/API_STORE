using API_FARMACIA_PM.Repositories;
using API_FARMACIA_PM.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API_FARMACIA_PM.controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly StockRepository _stockRepository;

    public StockController(StockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateStock([FromBody] StockRequest stockRequest)
    {
        try
        {
            var createdStock = await _stockRepository.CreateStock(stockRequest);
            return Ok(new { Estoque = createdStock });
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao criar o estoque: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStock(int id)
    {
        try
        {
            var stock = await _stockRepository.GetStock(id);

            if (stock is null)
                return NotFound($"Estoque com ID {id} não encontrado.");

            return Ok(new { Estoque = stock });
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao obter o estoque: {ex.Message}");
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateStock([FromBody] UpdateStockRequest updateStockRequest)
    {
        try
        {
            var updateStock = await _stockRepository.UpdateStock(updateStockRequest);
            if (updateStock is null)
                return NotFound($"Estoque com ID {updateStockRequest.Id} não encontrado.");
            return Ok(new { Estoque = updateStock });
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao atualizar o estoque: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStock(int id)
    {
        try
        {
            var stock = await _stockRepository.DeleteStock(id);

            if (stock is null)
                return NotFound($"Estoque com ID {id} não encontrado.");

            return Ok(new { Estoque = stock });
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao excluir o estoque: {ex.Message}");
        }
    }
}
