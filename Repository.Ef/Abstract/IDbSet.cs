namespace Repository.Ef.Abstract
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDbSet<TEntity> : IQueryable<TEntity> where TEntity: class
    {
        void Remove(TEntity entity);

        void RemoveRange(TEntity[] entities);

        void Add(TEntity entity);

        void AddRange(TEntity[] entities);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(TEntity[] entities);

        void Attach(TEntity entity);

        void AttachRange(TEntity[] entities);

        IQueryable<TEntity> FromSql(FormattableString query);
    }
}