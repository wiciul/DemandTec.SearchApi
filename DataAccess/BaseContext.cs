namespace DataAccess
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseContext : DbContext, IBaseContext
    {
        //private readonly ILoggerFactory _loggerFactory;

        protected BaseContext(DbContextOptions options/*, ILoggerFactory loggerFactory*/) : base(options)
        {
            //_loggerFactory = loggerFactory;
        }
        
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }*/

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}