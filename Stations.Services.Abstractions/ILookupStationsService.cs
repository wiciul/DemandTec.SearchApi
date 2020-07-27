namespace Stations.Services.Abstractions
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Models;

    public interface ILookupStationsService
    {
        Task<IEnumerable<Station>> GetByNameStartsWithAsync(string nameStart, int top = 10);

        Task<IEnumerable<Station>> GetByAnyNamePartAsync(string namePart, int top = 10);

        Task<IPage<Station>> GetStationsAsync(PageReq pageReq);
    }
}