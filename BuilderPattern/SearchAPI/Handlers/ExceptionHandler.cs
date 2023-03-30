using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Encodings.Web;
using SearchAPI.Models;

namespace SearchAPI.Handlers
{
    [ExcludeFromCodeCoverage]
    public class ExceptionHandler
    {
        public static async Task HandleExceptionAsync(HttpContext context)
        {
            var ex = context.Features.Get<IExceptionHandlerFeature>();
            var logger = context.RequestServices.GetService<ILogger<ExceptionHandler>>();

            ErrorResult result;
            HttpStatusCode statusCode;
            switch (ex.Error)
            {
                case UnauthorizedAccessException uex:
                    {
                        statusCode = HttpStatusCode.Unauthorized;
                        result = new ErrorResult(
                            Constants.ErrorCode.UnAuthorized,
                            HtmlEncoder.Default.Encode(ex.Error.Message),
                            uex?.InnerException?.Message
                        );
                        break;
                    }
                case ArgumentException aex:
                    {
                        statusCode = HttpStatusCode.BadRequest;
                        result = new ErrorResult(
                            Constants.ErrorCode.InvalidArgument,
                            HtmlEncoder.Default.Encode(ex.Error.Message),
                            aex?.InnerException?.Message
                        );
                        break;
                    }
                case NotFoundException notfoundex:
                    {
                        statusCode = HttpStatusCode.NotFound;
                        result = new ErrorResult(
                            Constants.ErrorCode.DocumentNotFound,
                            HtmlEncoder.Default.Encode(ex.Error.Message),
                            notfoundex?.InnerException?.Message
                        );
                        break;
                    }
                case InvalidOperationException invOpEx:
                    {
                        statusCode = HttpStatusCode.BadRequest;
                        result = new ErrorResult(
                            Constants.ErrorCode.InvalidOperation,
                            HtmlEncoder.Default.Encode(ex.Error.Message),
                            invOpEx?.InnerException?.Message
                        );
                        break;
                    }
                default:
                    {
                        statusCode = HttpStatusCode.InternalServerError;
                        result = new ErrorResult(
                            Constants.ErrorCode.Unknown,
                            Constants.ErrorMessage.Error_UnknownException,
                            null
                        );
                        break;
                    }
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}
