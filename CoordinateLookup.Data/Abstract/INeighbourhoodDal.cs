using CoordinateLookup.Dto.DTOs;

namespace CoordinateLookup.Data.Abstract
{
    public interface INeighbourhoodDal
    {
        Task<List<NeighbourhoodDto>> GetNeighbourhoodsByTownIdAsync(int townId);
    }
}
