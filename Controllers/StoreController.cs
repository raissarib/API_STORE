using API_FARMACIA_PM.Repositories;
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

}