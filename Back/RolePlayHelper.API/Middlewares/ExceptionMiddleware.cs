using RolePlayHelper.BLL.Exceptions;
using System.Text.Json;

namespace RolePlayHelper.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        public async Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            int statusCode = 400;

            switch(ex)
            {
                case RolePlayHelperException e:
                    await SendResponse(context, e);
                    break;

                case Exception:
                    statusCode = 500;
                    context.Response.StatusCode = statusCode;

                    var response = new
                    {
                        message = ex.Message,
                    };

                    string jsonResponse = JsonSerializer.Serialize(response);

                    await context.Response.WriteAsync(jsonResponse);
                    break;

                default:
                    throw new Exception("Last stand");
            }
        }

        public async Task SendResponse(HttpContext context, RolePlayHelperException ex)
        {
            context.Response.StatusCode = ex.StatusCode;

            var response = new
            {
                content = ex.Content
            };

            string jsonResponse = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
