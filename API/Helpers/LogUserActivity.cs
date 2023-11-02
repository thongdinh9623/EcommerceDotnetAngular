using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var resultContext = await next();
            var userIdentity = context.HttpContext.User.Identity;
            if (userIdentity == null || !userIdentity.IsAuthenticated)
            {
                return;
            }
            var userId = resultContext.HttpContext.User.GetUserId();
            var uow
                = resultContext.HttpContext.RequestServices
                    .GetService<IUnitOfWork>();
            if (uow == null)
            {
                throw new Exception("ERROR: OnActionExecutionAsync");
            }
            await uow.Complete();
        }
    }
}
