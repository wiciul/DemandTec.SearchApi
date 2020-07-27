namespace DataAccess
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Repository.Ef.Abstract;

    public class DbSetAdapter<TEntity> : IDbSet<TEntity> where TEntity: class
    {
        private readonly DbSet<TEntity> _entities;

        public DbSetAdapter(DbSet<TEntity> entities)
        {
            _entities = entities;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _entities.AsNoTracking().AsQueryable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType => _entities.AsQueryable().ElementType;

        public Expression Expression => _entities.AsQueryable().Expression;

        public IQueryProvider Provider => _entities.AsNoTracking().AsQueryable().Provider;

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(TEntity[] entities)
        {
            _entities.RemoveRange(entities);
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(TEntity[] entities)
        {
            _entities.AddRange(entities);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task AddRangeAsync(TEntity[] entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public void Attach(TEntity entity)
        {
            _entities.Attach(entity);
        }

        public void AttachRange(TEntity[] entities)
        {
            _entities.AttachRange(entities);
        }

        public IQueryable<TEntity> FromSql(FormattableString query)
        {
            return _entities.FromSqlInterpolated(query).AsNoTracking();
        }
    }
}
