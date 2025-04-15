using CoordinateLookup.Data.Abstract;
using CoordinateLookup.Dto.DTOs;
using CoordinateLookup.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateLookup.Data.Concrete.EntityFramework
{
    public class EfTownDal : ITownDal
    {
        private readonly CoordinateLookupDbContext _coordinateLookupDbContext;
        public EfTownDal(CoordinateLookupDbContext coordinateLookupDbContext)
        {
            _coordinateLookupDbContext = coordinateLookupDbContext;
        }

        public async Task<List<Town>> GetTownsByDistrictIdAsync(int districtId)
        {
            return await _coordinateLookupDbContext.Towns
                .Where(t => t.DistrictId == districtId)
                .ToListAsync();
        }

        public async Task<TownDto?> GetTownWithNeighbourhoodsAsync(int townId)
        {
            return await _coordinateLookupDbContext.Towns.Where(t => t.Id == townId)
                           .Include(d => d.Neighbourhoods)
                           .Select(d => new TownDto
                           {
                               Town = d.Name,
                               ZipCode = d.ZipCode,
                               Neighbourhoods = d.Neighbourhoods.Select(n => new NeighbourhoodDto
                               {
                                   Name = n.Name,
                               }).ToList()
                           })
                           .FirstOrDefaultAsync();
        }
    }
}
