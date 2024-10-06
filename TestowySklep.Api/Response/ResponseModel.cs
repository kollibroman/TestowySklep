using TestowySklep.Api.Response.Interfaces;

namespace TestowySklep.Api.Response;

public class ResponseModel : IResponseModel
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
}