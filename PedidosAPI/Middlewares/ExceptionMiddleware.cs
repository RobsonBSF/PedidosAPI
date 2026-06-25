using System.Net;
using System.Text.Json;
using PedidosAPI.Application.Exceptions;

namespace PedidosAPI.Middlewares
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
            HttpStatusCode statusCode;
            string errorMessage = exception.Message;

            if (exception is NotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
            }
            else if (exception is BusinessException)
            {
                statusCode = HttpStatusCode.UnprocessableEntity;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                errorMessage = "Erro interno do servidor.";
            }

            var response = new
            {
                erro = errorMessage,
                status = (int)statusCode,
                timestamp = DateTime.UtcNow
            };

            var json = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(json);
        }
    }
}
