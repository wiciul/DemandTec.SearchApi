namespace Stations.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Abstractions;
    using Repository.Abstractions;
    using System.Linq;
    using Microsoft.EntityFrameworkCore; // TODO: implement and inject adapter for EntityFrameworkQueryableExtensions

    public class LookupStationsService : ILookupStationsService
    {
        private readonly IRepository<Station> _stations;

        public LookupStationsService(IRepository<Station> stations)
        {
            _stations = stations;
        }

        public async Task<IEnumerable<Station>> GetByNameStartsWithAsync(string nameStart, int top = 10)
        {
            return await _stations.AsQueryable()
                .Where(s => s.Name.ToLower().StartsWith(nameStart.ToLower()))
                .OrderBy(s => s.Name)
                .Take(top)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Station>> GetByAnyNamePartAsync(string namePart, int top = 10)
        {
            return await _stations.AsQueryable()
                .Where(s => s.Name.ToLower().Contains(namePart.ToLower()))
                .OrderBy(s => s.Name)
                .Take(top)
                .ToArrayAsync();
        }

        public async Task<IPage<Station>> GetStationsAsync(PageReq pageReq)
        {
            return new Page<Station>
            {
                Count = await _stations.AsQueryable().CountAsync(),
                Items = await _stations.AsQueryable()
                    .OrderBy(s => s.Name)
                    .Skip((pageReq.PageIndex - 1) * pageReq.PageSize)
                    .Take(pageReq.PageSize)
                    .ToArrayAsync()
            };
        }
    }
}