using CoordinateLookup.Business.Abstract;
using CoordinateLookup.Dto.DTOs;
using CoordinateLookup.Shared.Common.Utilities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoordinateLookup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighbourhoodController : ControllerBase
    {
        private readonly INeighbourhoodService _neighbourhoodService;
        public NeighbourhoodController(INeighbourhoodService neighbourhoodService)
        {
            _neighbourhoodService = neighbourhoodService;
        }
        [HttpGet]
        [Route("GetNeighbourhoodsByTownId")]
        public async Task<Response<List<NeighbourhoodDto>>> GetNeighbourhoodsByTownIdAsync(int townId)
        {
            return await _neighbourhoodService.GetNeighbourhoodsByTownIdAsync(townId);
        }
    }
}
