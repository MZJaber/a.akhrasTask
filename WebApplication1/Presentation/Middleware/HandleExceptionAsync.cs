using System;
using System.Net;
using System.Text.Json;

namespace WebApplication1.Presentation.Middleware
{
    public class HandleExceptionAsync : IMiddleware
    {
        public HttpStatusCode statusCode;
        string message = "error";

        public async Task ErrorName(HttpContext context, Exception exception)
        {
            switch (exception)
            {
                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    message = "Not Found";
                    break;

                case UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;
                    message = "Unauthorized";
                    break;

                case ArgumentException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = "BadRequest";
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                statusCode = context.Response.StatusCode,
                Message = message,
                Detail = exception.Message
            };

            await context.Response.WriteAsJsonAsync(response);
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
        }

        public class GlobalExceptionMiddleware
        {

            private readonly RequestDelegate _next;

            public GlobalExceptionMiddleware(RequestDelegate next)
            {
                _next = next;
            }


            public async Task InvokeAsync(HttpContext context)
            {
                try
                {

                    await _next(context);
                }
                catch (Exception ex)
                {

                    await HandleExceptionAsync(context, ex);
                }
            }

            private static Task HandleExceptionAsync(HttpContext context, Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new
                {
                    statusCode = context.Response.StatusCode,
                    Message = "Internal Server",
                    Detail = ex.Message
                };

                var jsonResponse = JsonSerializer.Serialize(response);

                return context.Response.WriteAsJsonAsync(jsonResponse);
            }
        }
    }
}

