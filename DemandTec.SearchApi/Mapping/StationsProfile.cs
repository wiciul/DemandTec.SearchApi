namespace DemandTec.SearchApi.Mapping
{
    using AutoMapper;
    using Dto;
    using Stations.Services.Abstractions;

    public class StationsProfile : Profile
    {
        public StationsProfile()
        {
            CreateMap<Models.Station, Station>();
            CreateMap<Dto.PageReq, Stations.Services.Abstractions.PageReq>();
            CreateMap(typeof(IPage<>), typeof(PageResp<>));
        }
    }
}
