using API_FARMACIA_PM.Repositories;
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

}