namespace Repository.Abstractions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> AsQueryable();

        void Remove(T entity);

        void RemoveRange(T[] entities);

        void Add(T entity);

        void AddRange(T[] entities);

        Task AddAsync(T entity);

        Task AddRangeAsync(T[] entities);

        void Update(T entity);

        void UpdateRange(T[] entities);

        IQueryable<T> FromSql(FormattableString query);
    }
}