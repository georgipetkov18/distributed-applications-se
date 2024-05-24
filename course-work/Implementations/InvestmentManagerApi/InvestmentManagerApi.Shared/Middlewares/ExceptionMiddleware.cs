using InvestmentManagerApi.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace InvestmentManagerApi.Shared.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NotFoundException e)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new { e.Message }));
            }
        }
    }
}
