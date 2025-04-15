using CoordinateLookup.Business.Abstract;
using CoordinateLookup.DTOs;
using CoordinateLookup.Shared.Common.Utilities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoordinateLookup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;
        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }
        [HttpGet]
        [Route("GetDistrictsByProvinceId")]
        public async Task<Response<List<District>>> GetDistrictsByProvinceIdAsync(int provinceId)
        {
            return await _districtService.GetDistrictsByProvinceIdAsync(provinceId);
        }
        [HttpGet]
        [Route("GetDistrictWithTowns")]
        public async Task<Response<DistrictDto?>> GetDistrictWithTownsAsync(int districtId)
        {
            return await _districtService.GetDistrictWithTownsAsync(districtId);
        }
    }
}
