using API_FARMACIA_PM.Repositories;
using API_FARMACIA_PM.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API_FARMACIA_PM.controllers;

[Route("api/[controller]")]
[ApiController]
public class StoreController : ControllerBase
{
    private readonly StoreRepository _storeRepository;

    public StoreController(StoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateStore([FromBody] StoreRequest storeRequest)
    {
        try
        {
            var createdStore = await _storeRepository.CreateStore(storeRequest);
            return Ok(new { Loja = createdStore });
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao criar a loja: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStore(int id)
    {
        try
        {
            var store = await _storeRepository.GetStore(id);

            if (store is null)
                return NotFound($"Loja com ID {id} não encontrada.");

            return Ok(new { Loja = store });
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao obter a loja: {ex.Message}");
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateStore([FromBody] UpdateStoreRequest updateStoreRequest)
    {
        try
        {
            var updateStore = await _storeRepository.UpdateStore(updateStoreRequest);
            if (updateStore is null)
              return NotFound($"Loja com ID {updateStoreRequest.Id} não encontrada.");
              return Ok(new { Loja = updateStore });

        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao criar a loja: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStore(int id)
    {
        try
        {
            var store = await _storeRepository.DeleteStore(id);

            if (store is null)
                return NotFound($"Loja com ID {id} não encontrada.");

            return Ok(new { Loja = store });
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao obter a loja: {ex.Message}");
        }
}
}