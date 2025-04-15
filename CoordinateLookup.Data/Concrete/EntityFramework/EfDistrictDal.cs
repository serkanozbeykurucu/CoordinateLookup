using CoordinateLookup.Data.Abstract;
using CoordinateLookup.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CoordinateLookup.Data.Concrete.EntityFramework
{
    public class EfDistrictDal : IDistrictDal
    {
        private readonly CoordinateLookupDbContext _coordinateLookupDbContext;
        public EfDistrictDal(CoordinateLookupDbContext coordinateLookupDbContext)
        {
            _coordinateLookupDbContext = coordinateLookupDbContext;
        }

        public async Task<List<District>> GetDistrictsByProvinceIdAsync(int provinceId)
        {
            return await _coordinateLookupDbContext.Districts
                .Where(d => d.ProvinceId == provinceId)
                .ToListAsync();
        }

        public async Task<List<DistrictDto>> GetDistrictWithCoordinatesByClosestProvinceIdAsync(int closestProvinceId)
        {
            return await _coordinateLookupDbContext.Districts.Where(d => d.ProvinceId == closestProvinceId).Select(d => new DistrictDto
            {
                Id = d.Id,
                District = d.Name,
                Latitude = d.Latitude,
                Longitude = d.Longitude,
            }).ToListAsync();
        }

        public async Task<DistrictDto?> GetDistrictWithTownsAsync(int districtId)
        {
            return await _coordinateLookupDbContext.Districts.Where(d => d.Id == districtId)
                .Include(d => d.Towns)
                .Select(d => new DistrictDto
                {
                    District = d.Name,
                    Coordinates = d.Coordinates,
                    Latitude = d.Latitude,
                    Longitude = d.Longitude,
                    Towns = d.Towns.Select(t => new TownDto
                    {
                        Town = t.Name,
                        ZipCode = t.ZipCode,
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}
