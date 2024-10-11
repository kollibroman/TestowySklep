using System.Text.RegularExpressions;
using TestowySklep.Api.Response.Interfaces;
using TestowySklep.Api.Persitence.Models;
using TestowySklep.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestowySklep.Api.Request.User;

namespace TestowySklep.Api.Api;

public static class UserApi
{
    public static IEndpointRouteBuilder MapUser(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/user");
        
        group.WithTags("User");

        group.MapGet("/", GetUsersAsync);
        group.MapGet("/{id}", GetUserByIdAsync);
        group.MapPost("/", CreateUserAsync).DisableAntiforgery();
        group.MapPatch("/{id}", UpdateUserAsync);
        group.MapDelete("/{id}", DeleteUserAsync);
        
        return routes;
    }

    private static async Task<Results<Ok<IResponseDataModel<IAsyncEnumerable<User>>>, BadRequest>> GetUsersAsync([FromServices]IUserService service, CancellationToken ct)
    {
        var result = await service.GetUsersAsync(ct);
        return result.Success ? TypedResults.Ok(result) : TypedResults.BadRequest();
    }
    
    private static async Task<Results<Ok<IResponseDataModel<User>>, BadRequest>> GetUserByIdAsync([FromRoute] int id, [FromServices]IUserService service, CancellationToken ct)
    {
        var result = await service.GetUserByIdAsync(id, ct);
        return result.Success ? TypedResults.Ok(result) : TypedResults.BadRequest();
    }

    private static async Task<Results<Ok<IResponseModel>, BadRequest>> CreateUserAsync([FromBody] AddUserDto dto,
        [FromServices] IUserService service, CancellationToken ct)
    {
        var result = await service.CreateUserAsync(dto, ct);
        return result.Success ? TypedResults.Ok(result) : TypedResults.BadRequest();
    }

    private static async Task<Results<Ok<IResponseModel>, BadRequest>> UpdateUserAsync([FromRoute] int id,
        [FromBody] UpdateUserDto dto,
        [FromServices] IUserService service, CancellationToken ct)
    {
        var result = await service.UpdateUserAsync(id, dto, ct);
        return result.Success ? TypedResults.Ok(result) : TypedResults.BadRequest();
    }
    
    private static async Task<Results<Ok<IResponseModel>, BadRequest>> DeleteUserAsync([FromRoute] int id, [FromServices] IUserService service, CancellationToken ct)
    {
        var result = await service.DeleteUserAsync(id, ct);
        return result.Success ? TypedResults.Ok(result) : TypedResults.BadRequest();
    }
}