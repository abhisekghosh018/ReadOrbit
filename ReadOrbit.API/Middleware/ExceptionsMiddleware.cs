using System.Net;
using System.Text.Json;

namespace ReadOrbit.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionsMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionsMiddleware(RequestDelegate next, ILogger<ExceptionsMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
              await _next(httpContext);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex,ex.Message);    
                await HandelException(httpContext, ex);
            }
        }

        private Task HandelException(HttpContext httpContext, Exception ex) 
        {
             httpContext.Response.ContentType = "application/json";
             //httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            int statusCode=0;
            string message = ex.Message;

            switch (ex)
            {
                case DllNotFoundException:
                    statusCode = StatusCodes.Status404NotFound;
                    break;
                case ArgumentException:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    message = "An unexpected error occurred.";
                    break;
            }

            var response = _env.IsDevelopment()
                    ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException((int)HttpStatusCode.InternalServerError);


            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);

            return httpContext.Response.WriteAsync(json);

        }
    }


    public class ApiException
    {
        public ApiException(int statusCode, string message = null, string details = null)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}
