using CoordinateLookup.DTOs;
using CoordinateLookup.Shared.Common.Utilities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateLookup.Business.Abstract
{
    public interface ITownService
    {
        Task<Response<List<Town>>> GetTownsByDistrictIdAsync(int districtId);
        Task<Response<TownDto?>> GetTownWithNeighbourhoodsAsync(int townId);
    }
}
