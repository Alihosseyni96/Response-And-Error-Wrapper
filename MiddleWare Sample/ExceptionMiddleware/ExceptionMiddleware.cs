using MiddleWare_Sample.ResultViewModel;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MiddleWare_Sample.ExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }

            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetials = new FuncResult();
            switch (exception)
            {
                case InvalidOperationException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorDetials.Status = (Status)context.Response.StatusCode;
                    errorDetials.Error = new Error() { Message = "NotFound" };
                    break;

                case NullReferenceException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorDetials.Status = (Status)context.Response.StatusCode;
                    errorDetials.Error = new Error() { Message = "NotFound" };
                    break;

                case ArgumentNullException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorDetials.Status = (Status)context.Response.StatusCode;
                    errorDetials.Error = new Error() { Message = "BadRequest" };
                    break;

                case KeyNotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorDetials.Status = (Status)context.Response.StatusCode;
                    errorDetials.Error = new Error() { Message = "NotFound" };
                    break;

                case OperationCanceledException:
                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    errorDetials.Status = (Status)context.Response.StatusCode;
                    errorDetials.Error = new Error() { Message = "Conflict" };
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorDetials.Status = (Status)context.Response.StatusCode;
                    errorDetials.Error = new Error() { Message = "InternalServerError" };
                    break;
            }

            await context.Response.WriteAsync(errorDetials.ToString());
        }
    }
}
