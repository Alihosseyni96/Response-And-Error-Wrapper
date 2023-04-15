using MiddleWare_Sample.ExceptionMiddleware;
using Newtonsoft.Json;
using System.IO.Pipelines;
using System.Net;
using System.Text.Json;

namespace MiddleWare_Sample.ResultViewModel
{
    public class StatusClass
    {
        private readonly RequestDelegate _next;
        public StatusClass(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            //using var buffer = new MemoryStream();
            //var body = httpContext.Response.Body;
            //httpContext.Response.Body = buffer;
            //await _next(httpContext);
            //string result = string.Empty;
            //buffer.Seek(0, SeekOrigin.Begin);
            //using (var stream = new StreamReader(buffer))
            //{
            //    string bodystr = await stream.ReadToEndAsync();
            //    var res = JsonConvert.DeserializeObject<FuncResult>(bodystr);
            //    httpContext.Response.StatusCode = (int)res.Status;
            //    return;
                //reset to start of stream
                //buffer.Seek(0, SeekOrigin.Begin);

                //copy our content to the original stream and put it back
                //await buffer.CopyToAsync(body);
                //httpContext.Response.Body = body;
            }
            //var res = JsonConvert.DeserializeObject<FuncResult>(httpContext.Response.Body.ToString());
            //httpContext.Response.StatusCode = (int)res.Status;
        }
    }

