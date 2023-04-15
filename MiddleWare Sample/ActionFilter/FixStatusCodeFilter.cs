using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MiddleWare_Sample.ResultViewModel;

namespace MiddleWare_Sample.ActionFilter
{
    public class FixStatusCodeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result;
            if (result is ObjectResult res)
            {
                var x = res.Value as FuncResult;
                context.HttpContext.Response.StatusCode = (int)x.Status;
            }

        }
    }
}
