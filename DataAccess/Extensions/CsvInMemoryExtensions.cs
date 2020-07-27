namespace DataAccess.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class CsvInMemoryExtensions
    {
        public static IServiceCollection AddStationsPersistence(this IServiceCollection services)
        {
            services.AddDbContextPool<StationsContext>(o =>
                o.UseInMemoryDatabase("Stations"));
            return services;
        }
    }
}