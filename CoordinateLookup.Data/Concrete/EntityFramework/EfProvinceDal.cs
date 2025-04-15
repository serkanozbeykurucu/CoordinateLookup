using CoordinateLookup.Data.Abstract;
using CoordinateLookup.Dto.DTOs;
using CoordinateLookup.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CoordinateLookup.Data.Concrete.EntityFramework
{
    public class EfProvinceDal : IProvinceDal
    {
        private readonly CoordinateLookupDbContext _coordinateLookupDbContext;
        public EfProvinceDal(CoordinateLookupDbContext coordinateLookupDbContext)
        {
            _coordinateLookupDbContext = coordinateLookupDbContext;
        }
        public async Task<List<Province>> GetListProvincesAsync()
        {
            return await _coordinateLookupDbContext.Provinces.ToListAsync();
        }
        public async Task<ProvinceDto?> GetProvinceByIdAsync(int provinceId)
        {
            return await _coordinateLookupDbContext.Provinces
                .Where(p => p.Id == provinceId)
                .Include(p => p.Districts)
                .ThenInclude(d => d.Towns)
                .ThenInclude(t => t.Neighbourhoods)
                .Select(p => new ProvinceDto
                {
                    Id = p.Id,
                    Province = p.Name,
                    PlateNumber = p.PlateNumber,
                    Coordinates = p.Coordinates,
                    Latitude = p.Latitude,
                    Longitude = p.Longitude
                }).FirstOrDefaultAsync();
        }
        public async Task<List<ProvinceDto>> GetProvincesWithCoordinatesAsync()
        {
            return await _coordinateLookupDbContext.Provinces.Select(p => new ProvinceDto
            {
                Id = p.Id,
                Province = p.Name,
                Latitude = p.Latitude,
                Longitude = p.Longitude,
            }).ToListAsync();
        }
        public async Task<ProvinceDto?> GetProvinceWithDistrictsAsync(int provinceId)
        {
            return await _coordinateLookupDbContext.Provinces
                .Where(p => p.Id == provinceId)
                .Include(p => p.Districts)
                .Select(p => new ProvinceDto
                {
                    Province = p.Name,
                    PlateNumber = p.PlateNumber,
                    Coordinates = p.Coordinates,
                    Latitude = p.Latitude,
                    Longitude = p.Longitude,
                    Districts = p.Districts.Select(d => new DistrictDto
                    {
                        District = d.Name,
                        Coordinates = d.Coordinates,
                        Latitude = d.Latitude,
                        Longitude = d.Longitude
                    }).ToList()
                }).FirstOrDefaultAsync();
        }
    }
}
