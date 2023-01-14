using OP.SoftCaribbean.WebAPI.Middleware;

namespace OP.SoftCaribbean.WebAPI.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandleMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
