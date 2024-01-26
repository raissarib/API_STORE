using API_FARMACIA_PM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_FARMACIA_PM.controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductRepository _productRepository;
    
    public ProductController(ProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

}