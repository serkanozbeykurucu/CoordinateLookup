using CoordinateLookup.Business.Abstract;
using CoordinateLookup.DTOs;
using CoordinateLookup.Shared.Common.Utilities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoordinateLookup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        [HttpGet]
        [Route("GetProvinceById")]
        public async Task<Response<ProvinceDto>> GetProvinceByIdAsync(int provinceId)
        {
           return await _provinceService.GetProvinceByIdAsync(provinceId);
        }
        [HttpGet]
        [Route("GetAllProvinces")]
        public async Task<Response<List<Province>>> GetAllProvincesAsync()
        {
            return await _provinceService.GetAllProvincesAsync();
        }
        [HttpGet]
        [Route("GetProvinceWithDistricts")]
        public async Task<Response<ProvinceDto?>> GetProvinceWithDistrictsAsync(int provinceId)
        {
            return await _provinceService.GetProvinceWithDistrictsAsync(provinceId);
        }
    }
}