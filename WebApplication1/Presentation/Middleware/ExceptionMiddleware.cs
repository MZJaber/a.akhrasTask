namespace WebApplication1.Presentation.Middleware
{
    public class ExceptionMiddleware
    {

            private readonly RequestDelegate _next;

            public ExceptionMiddleware(RequestDelegate next)
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

            private static Task HandleExceptionAsync(HttpContext context, Exception exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "errors",
                    Detail = exception.Message 
                };

                return context.Response.WriteAsJsonAsync(response);
            }
        }

    }

