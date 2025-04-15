using CoordinateLookup.Data.Abstract;
using CoordinateLookup.Dto.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateLookup.Data.Concrete.EntityFramework
{
    public class EfNeighbourhoodDal : INeighbourhoodDal
    {
        private readonly CoordinateLookupDbContext _coordinateLookupDbContext;
        public EfNeighbourhoodDal(CoordinateLookupDbContext coordinateLookupDbContext)
        {
            _coordinateLookupDbContext = coordinateLookupDbContext;
        }
        public async Task<List<NeighbourhoodDto>> GetNeighbourhoodsByTownIdAsync(int townId)
        {
            return await _coordinateLookupDbContext.Neighbourhoods.Where(n => n.TownId == townId)
                .Include(n => n.Town)
                .Select(n => new NeighbourhoodDto
                {
                    Name = n.Name
                })
                .ToListAsync();
        }
    }
}
