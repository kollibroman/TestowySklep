using Microsoft.AspNetCore.Http.HttpResults;
using TestowySklep.Api.Response;
using TestowySklep.Api.Response.Interfaces;

namespace TestowySklep.Api.Api;

public static class InfrastructureApi
{
    public static IEndpointRouteBuilder AddInfrastructure(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/infrastructure");
        
        group.WithTags("Infrastructure");

        return routes;
    }

    private static Results<Ok<IResponseModel>, BadRequest> Ping()
    {
        var response = new ResponseModel
        {
            Success = true,
            Message = "Pong",
            StatusCode = 200
        };

        return TypedResults.Ok<IResponseModel>(response);
    }
}