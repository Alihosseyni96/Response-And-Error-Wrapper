using Microsoft.AspNetCore.Http;
using MiddleWare_Sample.ResultViewModel;
using Newtonsoft.Json;

namespace MiddleWare_Sample.ExceptionMiddleware
{
    public class ResponseRewindMiddleware
    {
        private readonly RequestDelegate _next;
        public ResponseRewindMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Stream orginalBody = context.Response.Body;
            try
            {
                using(var memstream = new MemoryStream())
                {
                    context.Response.Body = memstream;
                    await _next(context);
                    memstream.Position = 0;
                    string responseBody = new StreamReader(memstream).ReadToEnd();
                    var res = JsonConvert.DeserializeObject<FuncResult>(responseBody);
                    context.Response.StatusCode = (int)res.Status;

                    memstream.Position = 0;
                    await memstream.CopyToAsync(orginalBody);
                }
            }
            finally
            {
                context.Response.Body = orginalBody;
            }
        }
    }
}
