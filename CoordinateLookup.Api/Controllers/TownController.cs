using CoordinateLookup.Business.Abstract;
using CoordinateLookup.DTOs;
using CoordinateLookup.Shared.Common.Utilities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoordinateLookup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownController : ControllerBase
    {
        private readonly ITownService _townService;
        public TownController(ITownService townService)
        {
            _townService = townService;
        }
        [HttpGet]
        [Route("GetTownsByDistrictId")]
        public async Task<Response<List<Town>>> GetTownsByDistrictIdAsync(int districtId)
        {
            return await _townService.GetTownsByDistrictIdAsync(districtId);
        }
        [HttpGet]
        [Route("GetTownWithNeighbourhoods")]
        public async Task<Response<TownDto?>> GetTownWithNeighbourhoodsAsync(int townId)
        {
            return await _townService.GetTownWithNeighbourhoodsAsync(townId);
        }
    }
}