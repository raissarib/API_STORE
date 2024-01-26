using API_FARMACIA_PM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_FARMACIA_PM.controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;
    
    public UserController(UserRepository userRepository)
    {
      _userRepository = userRepository;
    }

}