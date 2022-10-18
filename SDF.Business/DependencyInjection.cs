using Microsoft.Extensions.DependencyInjection;
using SDF.Business.Implementations;
using SDF.Business.Interfaces;

namespace SDF.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection CreateBusinessDependencies(this IServiceCollection services)
        {
            services.AddScoped<IQuoteService, QuoteService>();

            return services;
        }
    }
}
