using CoordinateLookup.Business.Abstract;
using CoordinateLookup.Data.Abstract;
using CoordinateLookup.Dto.DTOs;
using CoordinateLookup.Shared.Common.Utilities.ComplexTypes;
using CoordinateLookup.Shared.Common.Utilities.Concrete;
using CoordinateLookup.Shared.Helpers;

namespace CoordinateLookup.Business.Concrete
{
    public class DistanceService : IDistanceService
    {
        private readonly IDistanceDal _distanceDal;
        public DistanceService(IDistanceDal distanceDal)
        {
            _distanceDal = distanceDal;
        }
        public async Task<Response<DistanceDto>> GetDistanceBetweenDistrictsAsync(int firstDistrictId, int secondDistrictId)
        {
            var firstDistrict = await _distanceDal.GetDistrictCoordinatesAsync(firstDistrictId);
            var secondDistrict = await _distanceDal.GetDistrictCoordinatesAsync(secondDistrictId);
            if (firstDistrict == null || secondDistrict == null)
            {
                return new Response<DistanceDto>(ResponseCode.NotFound, null, "District not found");
            }
            var firstCoordinates = firstDistrict;
            var secondCoordinates = secondDistrict;
            var distance = GeoHelper.CalculateDistance(firstCoordinates.Latitude, firstCoordinates.Longitude, secondCoordinates.Latitude, secondCoordinates.Longitude);
            return new Response<DistanceDto>(ResponseCode.Success, new DistanceDto
            {
                DistanceInKm = distance,
                FirstLocation = firstDistrict.Name,
                SecondLocation = secondDistrict.Name
            }, "Distance calculated successfully." );
        }
        public async Task<Response<DistanceDto>> GetDistanceBetweenProvincesAsync(int firstProvinceId, int secondProvinceId)
        {
            var firstProvince = await _distanceDal.GetProvinceCoordinatesAsync(firstProvinceId);
            var secondProvince = await _distanceDal.GetProvinceCoordinatesAsync(secondProvinceId);
            if (firstProvince == null || secondProvince == null)
            {
                return new Response<DistanceDto>(ResponseCode.NotFound, null, "Province not found");
            }
            var firstCoordinates = firstProvince;
            var secondCoordinates = secondProvince;
            var distance = GeoHelper.CalculateDistance(firstCoordinates.Latitude, firstCoordinates.Longitude, secondCoordinates.Latitude, secondCoordinates.Longitude);
            return new Response<DistanceDto>(ResponseCode.Success, new DistanceDto
            {
                DistanceInKm = Convert.ToDouble(distance),
                FirstLocation = firstProvince.Name,
                SecondLocation = secondProvince.Name
            }, "Distance calculated successfully.");
        }

        public async Task<Response<DistanceDto>> GetDistanceByDistrictNamesAsync(string firstDistrict, string secondDistrict)
        {
            var firstDistrictResult = await _distanceDal.FindDistrictByNameAsync(firstDistrict);
            var secondDistrictResult = await _distanceDal.FindDistrictByNameAsync(secondDistrict);
            if (firstDistrictResult == null || secondDistrictResult == null)
            {
                return new Response<DistanceDto>(ResponseCode.NotFound, null, "District not found");
            }
            var firstCoordinates = await _distanceDal.GetDistrictCoordinatesAsync(firstDistrictResult.Id);
            var secondCoordinates = await _distanceDal.GetDistrictCoordinatesAsync(secondDistrictResult.Id);
            var distance = GeoHelper.CalculateDistance(firstCoordinates.Latitude, firstCoordinates.Longitude, secondCoordinates.Latitude, secondCoordinates.Longitude);
            return new Response<DistanceDto>(ResponseCode.Success, new DistanceDto
            {
                DistanceInKm = distance,
                FirstLocation = firstDistrictResult.Name,
                SecondLocation = secondDistrictResult.Name
            }, "Distance calculated successfully.");
        }

        public async Task<Response<DistanceDto>> GetDistanceByProvinceNamesAsync(string firstProvince, string secondProvince)
        {
            var firstProvinceResult = await _distanceDal.FindProvinceByNameAsync(firstProvince);
            var secondProvinceResult = await _distanceDal.FindProvinceByNameAsync(secondProvince);

            if (firstProvinceResult == null || secondProvinceResult == null)
            {
                return new Response<DistanceDto>(ResponseCode.NotFound, null, "Province not found");
            }

            var firstCoordinates = await _distanceDal.GetProvinceCoordinatesAsync(firstProvinceResult.Id);
            var secondCoordinates = await _distanceDal.GetProvinceCoordinatesAsync(secondProvinceResult.Id);

            var distance = GeoHelper.CalculateDistance(firstCoordinates.Latitude, firstCoordinates.Longitude, secondCoordinates.Latitude, secondCoordinates.Longitude);

            return new Response<DistanceDto>(ResponseCode.Success, new DistanceDto
            {
                DistanceInKm = distance,
                FirstLocation = firstProvinceResult.Name,
                SecondLocation = secondProvinceResult.Name
            }, "Distance calculated successfully.");
        }
    }
}
