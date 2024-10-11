using TestowySklep.Api.Persitence.Models;
using TestowySklep.Api.Response.Interfaces;

namespace TestowySklep.Api.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IResponseDataModel<IAsyncEnumerable<User>>> GetUsersAsync(CancellationToken ct);
    Task<IResponseDataModel<User>> GetUserByIdAsync(int id, CancellationToken ct);
    Task<IResponseModel> CreateUserAsync(User user, CancellationToken ct);
    Task<IResponseModel> UpdateUserAsync(int id, string email, int age, bool isMale, CancellationToken ct);
    Task<IResponseModel> DeleteUserAsync(int id, CancellationToken ct);

}