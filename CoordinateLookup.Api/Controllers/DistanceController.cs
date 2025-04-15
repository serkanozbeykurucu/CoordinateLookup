using CoordinateLookup.Business.Abstract;
using CoordinateLookup.Dto.DTOs;
using CoordinateLookup.Shared.Common.Utilities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoordinateLookup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceController : ControllerBase
    {
        private readonly IDistanceService _distanceService;
        public DistanceController(IDistanceService distanceService)
        {
            _distanceService = distanceService;
        }
        [HttpGet]
        [Route("GetDistanceBetweenProvinces")]
        public async Task<Response<DistanceDto>> GetDistanceBetweenProvincesAsync(int firstProvinceId, int secondProvinceId)
        {
            return await _distanceService.GetDistanceBetweenProvincesAsync(firstProvinceId, secondProvinceId);
        }
        [HttpGet]
        [Route("GetDistanceBetweenDistricts")]
        public async Task<Response<DistanceDto>> GetDistanceBetweenDistrictsAsync(int firstDistrictId, int secondDistrictId)
        {
            return await _distanceService.GetDistanceBetweenDistrictsAsync(firstDistrictId, secondDistrictId);
        }
        [HttpGet]
        [Route("GetDistanceByProvinceNames")]
        public async Task<Response<DistanceDto>> GetDistanceByProvinceNamesAsync(string firstProvince, string secondProvince)
        {
            return await _distanceService.GetDistanceByProvinceNamesAsync(firstProvince, secondProvince);
        }        
        [HttpGet]
        [Route("GetDistanceByDistrictNames")]
        public async Task<Response<DistanceDto>> GetDistanceByDistrictNamesAsync(string firstDistrict, string secondDistrict)
        {
            return await _distanceService.GetDistanceByDistrictNamesAsync(firstDistrict, secondDistrict);
        }
    }
}
