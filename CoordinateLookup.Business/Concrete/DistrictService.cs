using CoordinateLookup.Business.Abstract;
using CoordinateLookup.Data.Abstract;
using CoordinateLookup.DTOs;
using CoordinateLookup.Shared.Common.Utilities.ComplexTypes;
using CoordinateLookup.Shared.Common.Utilities.Concrete;

namespace CoordinateLookup.Business.Concrete
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictDal _districtDal;
        public DistrictService(IDistrictDal districtDal)
        {
            _districtDal = districtDal;
        }
        public async Task<Response<List<District>>> GetDistrictsByProvinceIdAsync(int provinceId)
        {
            var districts = await _districtDal.GetDistrictsByProvinceIdAsync(provinceId);
            if (districts == null || !districts.Any())
            {
                return new Response<List<District>>(ResponseCode.NotFound,"No districts found for the given province ID.");
            }
            return new Response<List<District>>(ResponseCode.Success, districts, "Districts retrieved successfully.");
        }

        public async Task<Response<DistrictDto?>> GetDistrictWithTownsAsync(int districtId)
        {
            var district = await _districtDal.GetDistrictWithTownsAsync(districtId);
            if (district == null)
            {
                return new Response<DistrictDto?>(ResponseCode.NotFound, "District not found.");
            }
            return new Response<DistrictDto?>(ResponseCode.Success, district, "District with towns retrieved successfully.");
        }
    }
}
