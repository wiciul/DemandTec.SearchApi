namespace Repository.Ef.Concrete
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Abstractions;
    using Abstract;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private readonly IDbSet<TEntity> _entities;

        private readonly IDbContext _context;

        public Repository(IDbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _entities;
        }

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

        public void Update(TEntity entity)
        {
            _entities.Attach(entity);
        }

        public void UpdateRange(TEntity[] entities)
        {
            _entities.AttachRange(entities);
        }

        public IQueryable<TEntity> FromSql(FormattableString query)
        {
            return _entities.FromSql(query);
        }
    }
}
