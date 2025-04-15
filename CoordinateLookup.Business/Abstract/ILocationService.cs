using CoordinateLookup.Shared.Common.Utilities.Concrete;
using CoordinateLookup.DTOs;
using CoordinateLookup.Dto.DTOs;

namespace CoordinateLookup.Business.Abstract
{
    public interface ILocationService
    {
        Task<Response<GeographicalLocationDto>> GetGeographicalLocationByLatitudeAndLongitudeAsync(CoordinatesDto coordinatesDto);
    }
}
