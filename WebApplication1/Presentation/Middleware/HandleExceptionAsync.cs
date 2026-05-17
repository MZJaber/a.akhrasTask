using System;
using System.Net;
using System.Text.Json;

namespace WebApplication1.Presentation.Middleware 
{




    public class HandleExceptionAsync : IMiddleware
    {
        HttpContext context;
        Exception exception;
        public HttpStatusCode statusCode ;
        string message = "error";

       

       
        public string eroorName()
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
                StatusCode = context.Response.StatusCode,
                Message = message,
                Detail = exception.Message
            };

            return context.Response.WriteAsJsonAsync(response).ToString();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
        }




























        //public class GlobalExceptionMiddleware
        //{

        //        private readonly RequestDelegate _next;

        //        public GlobalExceptionMiddleware(RequestDelegate next)
        //        {
        //            _next = next;
        //        }


        //        public async Task InvokeAsync(HttpContext context)
        //        {
        //            try
        //            {

        //                await _next(context);
        //            }
        //            catch (Exception ex)
        //            {

        //                await HandleExceptionAsync(context, ex);
        //            }
        //        }

        //        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        //        {
        //            context.Response.ContentType = "application/json";
        //            context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;

        //            var response = new
        //            {
        //                StatusCode = context.Response.StatusCode,
        //                Message = "Internal Server",
        //                Detail = ex.Message 
        //            };

        //        var jsonResponse = JsonSerializer.Serialize(response);

        //            return context.Response.WriteAsJsonAsync(jsonResponse);
        //        }
        //}

    }
}

