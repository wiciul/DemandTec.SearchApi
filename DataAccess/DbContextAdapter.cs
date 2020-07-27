namespace DataAccess
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Repository.Ef.Abstract;

    public class DbContextAdapter : IDbContext
    {
        private readonly DbContext _dbContext;

        public DbContextAdapter(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity: class 
        {
            return new DbSetAdapter<TEntity>(_dbContext.Set<TEntity>());
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}