using TestowySklep.Api.Persitence.Models;
using TestowySklep.Api.Request.User;
using TestowySklep.Api.Response.Interfaces;

namespace TestowySklep.Api.Services.Interfaces;

public interface IUserService
{
    Task<IResponseDataModel<IAsyncEnumerable<User>>> GetUsersAsync(CancellationToken ct);
    Task<IResponseDataModel<User>> GetUserByIdAsync(int id, CancellationToken ct);
    Task<IResponseModel> CreateUserAsync(AddUserDto dto, CancellationToken ct);
    Task<IResponseModel> UpdateUserAsync(int id, UpdateUserDto dto, CancellationToken ct);
    Task<IResponseModel> DeleteUserAsync(int id, CancellationToken ct);
}