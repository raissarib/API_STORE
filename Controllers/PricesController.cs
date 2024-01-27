using API_FARMACIA_PM.Repositories;
using API_FARMACIA_PM.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API_FARMACIA_PM.controllers;

[Route("api/[controller]")]
[ApiController]
public class PricesController : ControllerBase
{
    private readonly PricesRepository _pricesRepository;

    public PricesController(PricesRepository pricesRepository)
    {
        _pricesRepository = pricesRepository;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePrices([FromBody] PricesRequest pricesRequest)
    {
        try
        {
            var createdPrices = await _pricesRepository.CreatePrices(pricesRequest);
            return Ok(new { Precos = createdPrices });
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao criar o preço: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPrices(int id)
    {
        try
        {
            var prices = await _pricesRepository.GetPrices(id);

            if (prices is null)
                return NotFound($"Preço com ID {id} não encontrado.");

            return Ok(new { Precos = prices });
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao obter o preço: {ex.Message}");
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdatePrices(
        [FromBody] UpdatePricesRequest updatePricesRequest
    )
    {
        try
        {
            var updatePrices = await _pricesRepository.UpdatePrices(updatePricesRequest);
            if (updatePrices is null)
                return NotFound($"Preço com ID {updatePricesRequest.Id} não encontrado.");
            return Ok(new { Precos = updatePrices });
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao atualizar o preço: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePrices(int id)
    {
        try
        {
            var prices = await _pricesRepository.DeletePrices(id);

            if (prices is null)
                return NotFound($"Preço com ID {id} não encontrado.");

            return Ok(new { Precos = prices });
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao excluir o preço: {ex.Message}");
        }
    }
}
