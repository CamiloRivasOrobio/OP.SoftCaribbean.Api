using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OP.SoftCaribbean.Application.Interfaces;
using OP.SoftCaribbean.Shared.Services;

namespace OP.SoftCaribbean.Shared
{
    public static class ServiceExtensions
    {
        public static void AddSharedInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
