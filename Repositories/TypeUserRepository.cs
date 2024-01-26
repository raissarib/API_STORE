using API_FARMACIA_PM.Data.SqlServer;
using API_FARMACIA_PM.Models;
using API_FARMACIA_PM.Requests;
using Microsoft.Identity.Client;

namespace API_FARMACIA_PM.Repositories;

public class TypeUserRepository
{
    private readonly SqlServerContext _sqlServer;

    public TypeUserRepository(SqlServerContext sqlServer)
    {
        _sqlServer = sqlServer;
    }

    public async Task<TypeUserModel> CreateTypeUser(TypeUserRequest typeUserRequest) 
    {
        TypeUserModel typeUserModel = new TypeUserModel 
        {
            User = typeUserRequest.User
        };

        var result = await _sqlServer.TypeUsers.AddAsync(typeUserModel);
        return result.Entity;

    }
}

