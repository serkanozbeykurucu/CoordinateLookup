using CoordinateLookup.Business.Abstract;
using CoordinateLookup.Data.Abstract;
using CoordinateLookup.DTOs;
using CoordinateLookup.Shared.Common.Utilities.ComplexTypes;
using CoordinateLookup.Shared.Common.Utilities.Concrete;

namespace CoordinateLookup.Business.Concrete
{
    public class TownService : ITownService
    {
        private readonly ITownDal _townDal;
        public TownService(ITownDal townDal)
        {
            _townDal = townDal;
        }
        public async Task<Response<List<Town>>> GetTownsByDistrictIdAsync(int districtId)
        {
            var towns = await _townDal.GetTownsByDistrictIdAsync(districtId);
            if (towns == null || !towns.Any())
            {
                return new Response<List<Town>>(ResponseCode.NotFound, "No towns found for the given district ID.");
            }
            return new Response<List<Town>>(ResponseCode.Success, towns, "Towns retrieved successfully.");
        }
        public async Task<Response<TownDto?>> GetTownWithNeighbourhoodsAsync(int townId)
        {
            var town = await _townDal.GetTownWithNeighbourhoodsAsync(townId);
            if (town == null)
            {
                return new Response<TownDto?>(ResponseCode.NotFound, "Town not found.");
            }
            return new Response<TownDto?>(ResponseCode.Success, town, "Town with neighbourhoods retrieved successfully.");
        }
    }
}
