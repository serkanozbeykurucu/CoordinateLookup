using CoordinateLookup.Data.Abstract;
using CoordinateLookup.Dto.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoordinateLookup.Data.Concrete.EntityFramework
{
    public class EfDistanceDal : IDistanceDal
    {
        private readonly CoordinateLookupDbContext _context;
        public EfDistanceDal(CoordinateLookupDbContext context)
        {
            _context = context;
        }
        public async Task<District?> FindDistrictByNameAsync(string districtName)
        {
            return await _context.Districts.Where(d => d.Name.ToLower() == districtName.ToLower()).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<Province?> FindProvinceByNameAsync(string provinceName)
        {
            return await _context.Provinces.Where(d => d.Name.ToLower() == provinceName.ToLower()).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<CoordinatesDto> GetDistrictCoordinatesAsync(int districtId)
        {
            var district = await _context.Districts.Where(d => d.Id == districtId).AsNoTracking().FirstOrDefaultAsync();
            if (district != null)
            {
                return new CoordinatesDto
                {
                    Name = district.Name,
                    Latitude = (double)district.Latitude,
                    Longitude = (double)district.Longitude
                };
            }
            return new CoordinatesDto
            {
                Latitude = 0,
                Longitude = 0
            };
        }
        public async Task<CoordinatesDto> GetProvinceCoordinatesAsync(int provinceId)
        {
            var province = await _context.Provinces.Where(p => p.Id == provinceId).AsNoTracking().FirstOrDefaultAsync();
            if (province != null)
            {
                return new CoordinatesDto
                {
                    Latitude = (double)province.Latitude,
                    Longitude = (double)province.Longitude
                };
            }
            return new CoordinatesDto
            {
                Latitude = 0,
                Longitude = 0
            };
        }
    }
}