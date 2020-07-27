namespace DemandTec.SearchApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Stations.Services.Abstractions;
    using System.Threading.Tasks;
    using AutoMapper;
    using System.Collections.Generic;
    using Dto;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using Swashbuckle.AspNetCore.Annotations;

    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class StationsController : ControllerBase
    {
        private readonly ILogger<StationsController> _logger;

        private readonly ILookupStationsService _lookupStationsService;

        private readonly IMapper _mapper;

        public StationsController(ILogger<StationsController> logger,
            ILookupStationsService lookupStationsService, IMapper mapper)
        {
            _logger = logger;
            _lookupStationsService = lookupStationsService;
            _mapper = mapper;
        }

        [HttpGet("startswith")]
        [SwaggerOperation(OperationId = "GetByNameStartsWith")]
        [ProducesResponseType(typeof(IEnumerable<Station>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Fault), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByNameStartsWithAsync([Required, FromQuery] string nameStart)
        {
            return Ok(_mapper.Map<IEnumerable<Station>>(
                await _lookupStationsService.GetByNameStartsWithAsync(nameStart)));
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(IEnumerable<Station>), (int)HttpStatusCode.OK)]
        [SwaggerOperation(OperationId = "GetByAnyNamePart")]
        [ProducesResponseType(typeof(Fault), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByAnyNamePartAsync([Required, FromQuery] string namePart)
        {
            return Ok(_mapper.Map<IEnumerable<Station>>(
                await _lookupStationsService.GetByAnyNamePartAsync(namePart)));
        }

        [HttpGet]
        [ProducesResponseType(typeof(PageResp<Station>), (int)HttpStatusCode.OK)]
        [SwaggerOperation(OperationId = "GetStations")]
        [ProducesResponseType(typeof(Fault), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetStationsAsync([Required, FromQuery] Dto.PageReq pageReq)
        {
            return Ok(_mapper.Map<PageResp<Station>>(
                await _lookupStationsService.GetStationsAsync(
                    _mapper.Map<Stations.Services.Abstractions.PageReq>(pageReq))));
        }
    }
}
