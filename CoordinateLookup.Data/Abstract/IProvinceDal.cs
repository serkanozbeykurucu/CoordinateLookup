using CoordinateLookup.DTOs;

namespace CoordinateLookup.Data.Abstract
{
    public interface IProvinceDal
    {
        Task<List<Province>> GetListProvincesAsync();
        Task<ProvinceDto?> GetProvinceByIdAsync(int provinceId);
        Task<ProvinceDto?> GetProvinceWithDistrictsAsync(int provinceId);
        Task<List<ProvinceDto>> GetProvincesWithCoordinatesAsync();
    }
}
