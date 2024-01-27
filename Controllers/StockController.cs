using API_FARMACIA_PM.Repositories;
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

}