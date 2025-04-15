using CoordinateLookup.Shared.Common.Utilities.Concrete;
using CoordinateLookup.DTOs;
using Microsoft.AspNetCore.Mvc;
using CoordinateLookup.Business.Abstract;
using CoordinateLookup.Dto.DTOs;

namespace CoordinateLookup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpGet]
        [Route("GetGeographicalLocationByLatitudeAndLongitudeAsync")]
        public async Task<Response<GeographicalLocationDto>> GetGeographicalLocationByLatitudeAndLongitudeAsync([FromBody] CoordinatesDto coordinates)
        {
            return await _locationService.GetGeographicalLocationByLatitudeAndLongitudeAsync(coordinates);
        }
    }
}
