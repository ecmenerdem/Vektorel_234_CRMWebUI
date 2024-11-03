using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Vektorel_234_CRM.Helper.SessionHelper;

namespace Vektorel_234_CRMWebUI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SessionNullCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionNullCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.Value.Contains("/Admin/"))
            {
                if (SessionManager.loginResponseDTO is null)
                {
                    httpContext.Response.Redirect("/AdminAccount/Login");
                    return;
                }
            }
            await _next(httpContext);

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SessionNullCheckMiddlewareExtensions
    {
        public static IApplicationBuilder UseSessionNullCheckMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SessionNullCheckMiddleware>();
        }
    }
}
