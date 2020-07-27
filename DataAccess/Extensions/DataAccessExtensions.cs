namespace DataAccess.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Repository.Abstractions;
    using Repository.Ef.Concrete;

    public static class DataAccessExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, Type context, IEnumerable<Type> repositories)
        {
            foreach (var repository in repositories)
            {
                services.AddScoped(typeof(IRepository<>).MakeGenericType(repository), s =>
                    Activator.CreateInstance(typeof(Repository<>).MakeGenericType(repository),
                        new DbContextAdapter(s.GetService(context) as DbContext)));
            }
            return services;
        }
    }
}