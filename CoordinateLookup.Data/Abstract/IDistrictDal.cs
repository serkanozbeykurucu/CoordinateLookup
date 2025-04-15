using CoordinateLookup.DTOs;

namespace CoordinateLookup.Data.Abstract
{
    public interface IDistrictDal
    {
        Task<List<DistrictDto>> GetDistrictWithCoordinatesByClosestProvinceIdAsync(int closestProvinceId);
        Task<List<District>> GetDistrictsByProvinceIdAsync(int provinceId);
        Task<DistrictDto?> GetDistrictWithTownsAsync(int districtId);
    }
}
