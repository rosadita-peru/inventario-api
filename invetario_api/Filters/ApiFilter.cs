using invetario_api.utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace invetario_api.Filters
{
    public class ApiFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Result is ObjectResult result && 
                   result.StatusCode is >= 200 and < 300 &&
                   result.Value is not ResponseApi<object>
                )
            {
                context.Result = new ObjectResult(
                        ResponseApi<object>.Success((int)result.StatusCode, "Success Api", result.Value)
                    );
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
