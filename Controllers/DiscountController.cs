using API_FARMACIA_PM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_FARMACIA_PM.controllers;
[Route("api/[controller]")]
[ApiController]
public class DiscountController : ControllerBase
{
    private readonly DiscountRepository _discountRepository;
    
    public DiscountController(DiscountRepository discountRepository)
    {
      _discountRepository = discountRepository;
    }

}