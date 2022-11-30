using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.Application.DTO;

namespace Store.Api.Filters
{
    public class UnhandledExceptions : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(ApiResult<string>.Failure(new List<string> { context.Exception.Message }));
        }
    }
}
