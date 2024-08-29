using System.Net;
using System.Net.Mime;
using System.Text.Json;
using SLaw.Application.Dtos;

namespace SLaw.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try { await this._next(context); }
            catch (Exception exception)
            {
                HttpResponse response = context.Response;

                response.ContentType = MediaTypeNames.Application.Json;

                HttpStatusCode statusCode = exception switch
                {
                    _                            => HttpStatusCode.InternalServerError
                };

                response.StatusCode = (int)statusCode;
                string userName = context.User.Identity?.Name;

                if (string.IsNullOrEmpty(userName) == false)
                {
                    this._logger.LogInformation($"Username : {userName}");
                }

                IPAddress ipAdress = context.Connection.RemoteIpAddress;

                if (ipAdress is not null)
                {
                    this._logger.LogInformation($"Ip Adress : {ipAdress}");
                }

                this._logger.LogError(exception.Message);

                CustomResponseDto responseModel = CustomResponseFailDto.Create(statusCode, exception.Message);

                string result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
