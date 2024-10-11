using TestowySklep.Api.Request;
using TestowySklep.Api.Response;
using TestowySklep.Api.Response.Interfaces;
using TestowySklep.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestowySklep.Api.Persitence.Models;
using TestowySklep.Api.Repositories.Interfaces;
using TestowySklep.Api.Request.User;

namespace TestowySklep.Api.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepository repository,
        ILogger<UserService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IResponseDataModel<IAsyncEnumerable<User>>> GetUsersAsync(CancellationToken ct)
    {
        return await _repository.GetUsersAsync(ct);
    }

    public async Task<IResponseDataModel<User>> GetUserByIdAsync(int id, CancellationToken ct)
    {
        return await _repository.GetUserByIdAsync(id, ct);
    }

    public Task<IResponseModel> CreateUserAsync(AddUserDto dto, CancellationToken ct)
    {
        var user = new User{
            Name = dto.Name,
            Email = dto.Email,
            Age = dto.Age,
            IsMale = dto.IsMale
            };
        
        return _repository.CreateUserAsync(user, ct);
    }

    public Task<IResponseModel> UpdateUserAsync(int id, UpdateUserDto dto, CancellationToken ct)
    {
         return _repository.UpdateUserAsync(id, dto.Email, dto.age, dto.IsMale, ct);
    }

    public Task<IResponseModel> DeleteUserAsync(int id, CancellationToken ct)
    {
        return _repository.DeleteUserAsync(id, ct);
    }
}