using CoordinateLookup.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateLookup.Data.Abstract
{
    public interface ITownDal
    {
        Task<List<Town>> GetTownsByDistrictIdAsync(int districtId);
        Task<TownDto?> GetTownWithNeighbourhoodsAsync(int townId);
    }    
}
