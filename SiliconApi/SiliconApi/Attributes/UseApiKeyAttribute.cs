using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SiliconApi.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
{

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var secret = "753fce7a-a9d3-4aa4-8b7e-66926d568e7b";

        if (context.HttpContext.Request.Query.TryGetValue("key", out var key))
        {
            if (!string.IsNullOrEmpty(key))
            {
                if (secret == key)
                    await next();
            }
        }

        context.Result = new UnauthorizedResult();
        return;
    }
}
