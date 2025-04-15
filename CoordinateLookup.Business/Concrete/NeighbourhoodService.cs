using CoordinateLookup.Business.Abstract;
using CoordinateLookup.Data.Abstract;
using CoordinateLookup.Dto.DTOs;
using CoordinateLookup.Shared.Common.Utilities.ComplexTypes;
using CoordinateLookup.Shared.Common.Utilities.Concrete;

namespace CoordinateLookup.Business.Concrete
{
    public class NeighbourhoodService : INeighbourhoodService
    {
        private readonly INeighbourhoodDal _neighbourhoodDal;
        public NeighbourhoodService(INeighbourhoodDal neighbourhoodDal)
        {
            _neighbourhoodDal = neighbourhoodDal;
        }
        public async Task<Response<List<NeighbourhoodDto>>> GetNeighbourhoodsByTownIdAsync(int townId)
        {
            var neighbourhoods = await _neighbourhoodDal.GetNeighbourhoodsByTownIdAsync(townId);
            if (neighbourhoods == null || neighbourhoods.Count == 0)
            {
                return new Response<List<NeighbourhoodDto>>(ResponseCode.NotFound,null, "No neighbourhoods found for the given town ID.");
            }
            return new Response<List<NeighbourhoodDto>>(ResponseCode.Success, neighbourhoods, "Neighbourhoods retrieved successfully.");
        }
    }
}
