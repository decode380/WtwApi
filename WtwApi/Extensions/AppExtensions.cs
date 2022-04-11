using Microsoft.AspNetCore.Builder;
using WtwApi.Middlewares;

namespace WtwApi
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
