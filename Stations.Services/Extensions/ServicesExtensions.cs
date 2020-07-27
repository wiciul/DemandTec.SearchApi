namespace Stations.Services.Extensions
{
    using DataAccess.Extensions;
    using Microsoft.Extensions.DependencyInjection;
    using Abstractions;
    using DataAccess;
    using Models;

    public static class ServicesExtensions
    {
        public static IServiceCollection AddStationsServices(this IServiceCollection services)
        {
            services.AddStationsPersistence();
            services.AddDataAccess(typeof(StationsContext), new[] {typeof(Station)});
            services.AddScoped<ILookupStationsService, LookupStationsService>();
            return services;
        }
    }
}