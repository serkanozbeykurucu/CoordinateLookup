using CoordinateLookup.Business.Abstract;
using CoordinateLookup.Data.Abstract;
using CoordinateLookup.DTOs;
using CoordinateLookup.Shared.Common.Utilities.ComplexTypes;
using CoordinateLookup.Shared.Common.Utilities.Concrete;

namespace CoordinateLookup.Business.Concrete
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceDal _provinceDal;
        public ProvinceService(IProvinceDal provinceDal)
        {
            _provinceDal = provinceDal;
        }
        public async Task<Response<List<Province>>> GetAllProvincesAsync()
        {
            var provinces = await _provinceDal.GetListProvincesAsync();
            if (provinces == null || !provinces.Any())
            {
                return new Response<List<Province>>(ResponseCode.NotFound, null,"No provinces found.");
            }
            return new Response<List<Province>>(ResponseCode.Success, provinces, "Provinces retrieved successfully.");
        }
        public async Task<Response<ProvinceDto?>> GetProvinceByIdAsync(int provinceId)
        {
            var province = await _provinceDal.GetProvinceByIdAsync(provinceId);
            if (province == null)
            {
                return new Response<ProvinceDto?>(ResponseCode.NotFound, null, "Province not found.");
            }
            return new Response<ProvinceDto?>(ResponseCode.Success, province, "Province retrieved successfully.");
        }
        public async Task<Response<ProvinceDto?>> GetProvinceWithDistrictsAsync(int provinceId)
        {
            var province = await _provinceDal.GetProvinceWithDistrictsAsync(provinceId);
            if (province == null)
            {
                return new Response<ProvinceDto?>(ResponseCode.NotFound, null, "Province not found.");
            }
            return new Response<ProvinceDto?>(ResponseCode.Success, province, "Province with districts retrieved successfully.");
        }
    }
}
