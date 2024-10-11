using TestowySklep.Api.Api;

namespace TestowySklep.Api.Extensions;

public static class ApiEndpointsExtensions
{
    public static void RegisterApiEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.AddInfrastructure();
        builder.MapUser();
    }
}