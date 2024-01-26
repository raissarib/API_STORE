using API_FARMACIA_PM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_FARMACIA_PM.controllers;
[Route("api/[controller]")]
[ApiController]
public class TypeUserController : ControllerBase
{
    private readonly TypeUserRepository _typeUserRepository;
    
    public TypeUserController(TypeUserRepository typeUserRepository)
    {
      _typeUserRepository = typeUserRepository;
    }

}