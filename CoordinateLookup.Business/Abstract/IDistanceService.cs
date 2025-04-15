using CoordinateLookup.Dto.DTOs;
using CoordinateLookup.Shared.Common.Utilities.Concrete;

namespace CoordinateLookup.Business.Abstract
{
    public interface IDistanceService
    {
        Task<Response<DistanceDto>> GetDistanceBetweenProvincesAsync(int firstProvinceId, int secondProvinceId);
        Task<Response<DistanceDto>> GetDistanceBetweenDistrictsAsync(int firstDistrictId, int secondDistrictId);
        Task<Response<DistanceDto>> GetDistanceByProvinceNamesAsync(string firstProvince, string secondProvince);
        Task<Response<DistanceDto>> GetDistanceByDistrictNamesAsync(string firstDistrict, string secondDistrict);
    }
}
