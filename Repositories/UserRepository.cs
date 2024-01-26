using API_FARMACIA_PM.Data.SqlServer;
using API_FARMACIA_PM.Models;
using API_FARMACIA_PM.Requests;
using Microsoft.Identity.Client;

namespace API_FARMACIA_PM.Repositories;

public class UserRepository
{
    private readonly SqlServerContext _sqlServer;

    public UserRepository(SqlServerContext sqlServer)
    {
        _sqlServer = sqlServer;
    }

    public async Task<UserModel> CreateUser(UserRequest userRequest) 
    {
        UserModel userModel = new UserModel 
        {
            Name = userRequest.Name,
            Email = userRequest.Email,
            Phone = userRequest.Phone,
            TypeUser = userRequest.TypeUser
        };

        var result = await _sqlServer.Users.AddAsync(userModel);
        return result.Entity;

    }
}

