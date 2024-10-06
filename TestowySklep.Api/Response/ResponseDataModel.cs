using TestowySklep.Api.Response.Interfaces;

namespace TestowySklep.Api.Response;

public class ResponseDataModel<T> : ResponseModel, IResponseDataModel<T> where T : class
{
    public T Data { get; set; } = null!;
}