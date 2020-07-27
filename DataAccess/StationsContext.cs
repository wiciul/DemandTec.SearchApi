namespace DataAccess
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class StationsContext : BaseContext
    {
        public StationsContext(DbContextOptions<StationsContext> options) : base(options)
        {
        }

        public DbSet<Station> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}