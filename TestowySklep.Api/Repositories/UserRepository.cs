using TestowySklep.Api.Repositories.Interfaces;
using TestowySklep.Api.Response.Interfaces;
using TestowySklep.Api.Persitence.Models;

using Microsoft.EntityFrameworkCore;
using TestowySklep.Api.Extensions;
using TestowySklep.Api.Persitence;
using TestowySklep.Api.Response;


namespace TestowySklep.Api.Repositories;

public class UserRepository : IUserRepository
{
        private readonly TestowyDbContext _dbContext;
    public UserRepository(TestowyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<IResponseDataModel<IAsyncEnumerable<User>>> GetUsersAsync(CancellationToken ct)
    {
        var users = _dbContext.Users.Select(u => new User
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            Age = u.Age,
            IsMale = u.IsMale
        }).ToAsyncEnumerable(ct);
        
        return Task.FromResult<IResponseDataModel<IAsyncEnumerable<User>>>(new ResponseDataModel<IAsyncEnumerable<User>>
        {
            Message = "",
            Success = true,
            Data = users
        });
    }

    public async Task<IResponseDataModel<User>> GetUserByIdAsync(int id, CancellationToken ct)
    {
        var user = await _dbContext.Users.Where(u => u.Id == id).Select(u => new User
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            Age = u.Age,
            IsMale = u.IsMale,
        }).SingleOrDefaultAsync(ct);
        
        return user != null ? new ResponseDataModel<User>
        {
            Message = "",
            Success = true,
            Data = user
        } : 
        new ResponseDataModel<User>
        {
            Message = "User not found",
            Success = false,
            Data = null!
        };
    }

    public async Task<IResponseModel> CreateUserAsync(User user, CancellationToken ct)
    {
       await _dbContext.Users.AddAsync(user, ct);
       
       return await _dbContext.SaveChangesAsync(ct) == 1 ?
           new ResponseModel
           {
               Success = true
           } :
           new ResponseModel
           {
               Success = false
           };
    }

    public async Task<IResponseModel> UpdateUserAsync(int id, string email, int age, bool isMale, CancellationToken ct)
    {
        var updatedUser = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id, ct);

        if (updatedUser is not null)
        {
            _dbContext.Users
                .Where(u => u.Id == id)
                .ExecuteUpdate(b =>
                        b.SetProperty(u => u.Email, email)
                        .SetProperty(u => u.Age, age)
                        .SetProperty(u => u.IsMale, isMale)
                );

            _dbContext.Users.Update(updatedUser);
            
            return new ResponseModel
            {
                Success = true
            };
        }
        
        return new ResponseModel
        {
            Success = false
        };
    }

    public async Task<IResponseModel> DeleteUserAsync(int id, CancellationToken ct)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id, ct);

        if (user is not null)
        {
            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync(ct);
            return new ResponseModel
            {
                Success = true
            };
        }

        return new ResponseModel
        {
            Success = false,
            Message = "User not found"
        };
    }
}