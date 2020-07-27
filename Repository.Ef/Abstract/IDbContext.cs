namespace Repository.Ef.Abstract
{
    using System.Threading.Tasks;

    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity: class;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}