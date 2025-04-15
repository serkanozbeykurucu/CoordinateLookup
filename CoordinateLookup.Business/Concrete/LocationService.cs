using CoordinateLookup.Shared.Common.Utilities.ComplexTypes;
using CoordinateLookup.Shared.Common.Utilities.Concrete;
using CoordinateLookup.DTOs;
using CoordinateLookup.Business.Abstract;
using CoordinateLookup.Data.Abstract;
using CoordinateLookup.Shared.Helpers;
using CoordinateLookup.Dto.DTOs;
using FluentValidation;

namespace CoordinateLookup.Business.Concrete
{
    public class LocationService : ILocationService
    {
        private readonly IProvinceDal _provinceDal;
        private readonly IDistrictDal _districtDal;
        private readonly IValidator<CoordinatesDto> _coordinatesValidator;
        public LocationService(IProvinceDal provinceDal, IDistrictDal districtDal, IValidator<CoordinatesDto> coordinatesValidator)
        {
            _provinceDal = provinceDal;
            _districtDal = districtDal;
            _coordinatesValidator = coordinatesValidator;
        }
        public async Task<Response<GeographicalLocationDto>> GetGeographicalLocationByLatitudeAndLongitudeAsync(CoordinatesDto coordinatesDto)
        {
            var validationResult = await _coordinatesValidator.ValidateAsync(coordinatesDto);
            
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return new Response<GeographicalLocationDto>(ResponseCode.Fail, errorMessage);
            }

            var provinces = await _provinceDal.GetProvincesWithCoordinatesAsync();

            if (!provinces.Any())
            {
                return new Response<GeographicalLocationDto>(ResponseCode.NotFound, null, "No province found to check.");
            }

            var closestProvinceInfo = provinces
                .Select(p => new
                {
                    p.Id,
                    p.Province,
                    Distance = GeoHelper.Haversine(coordinatesDto.Latitude, coordinatesDto.Longitude, Convert.ToDouble(p.Latitude), Convert.ToDouble(p.Longitude))
                })
                .OrderBy(p => p.Distance)
                .FirstOrDefault();

            if (closestProvinceInfo == null)
            {
                return new Response<GeographicalLocationDto>(ResponseCode.Fail, "Closest province could not be determined.");
            }

            var districtsInProvince = await _districtDal.GetDistrictWithCoordinatesByClosestProvinceIdAsync(closestProvinceInfo.Id);

            if (!districtsInProvince.Any())
            {
                return new Response<GeographicalLocationDto>(ResponseCode.NotFound, $"The closest province ({closestProvinceInfo.Province}) was found, but no districts were registered in it.");
            }

            var closestDistrictInfo = districtsInProvince
                .Select(d => new
                {
                    d.District,
                    Distance = GeoHelper.Haversine(coordinatesDto.Latitude, coordinatesDto.Longitude, Convert.ToDouble(d.Latitude), Convert.ToDouble(d.Longitude))
                })
                .OrderBy(d => d.Distance)
                .FirstOrDefault();

            if (closestDistrictInfo == null)
            {
                return new Response<GeographicalLocationDto>(ResponseCode.Fail, $"The closest district (within {closestProvinceInfo.Province}) could not be determined.");
            }
            var responseDto = new GeographicalLocationDto
            {
                Province = closestProvinceInfo.Province,
                District = closestDistrictInfo.District
            };
            return new Response<GeographicalLocationDto>(ResponseCode.Success, responseDto, "Location successfully found");
        }
    }
}
