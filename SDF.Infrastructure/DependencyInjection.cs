using Microsoft.Extensions.DependencyInjection;
using SDF.Infrastructure.Implementations;
using SDF.Infrastructure.Interfaces;

namespace SDF.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection CreateInfrastructureDependencies(this IServiceCollection services)
        {            
            services.AddScoped<IQuoteRepository, QuoteRepository>();
            return services;
        }
    }
}
