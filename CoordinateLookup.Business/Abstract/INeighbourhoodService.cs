using CoordinateLookup.Dto.DTOs;
using CoordinateLookup.Shared.Common.Utilities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateLookup.Business.Abstract
{
    public interface INeighbourhoodService
    {
        Task<Response<List<NeighbourhoodDto>>> GetNeighbourhoodsByTownIdAsync(int townId);
    }
}
