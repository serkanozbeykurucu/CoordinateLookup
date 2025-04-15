using CoordinateLookup.Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateLookup.Data.Abstract
{
    public interface IDistanceDal
    {
        Task<CoordinatesDto> GetProvinceCoordinatesAsync(int provinceId);
        Task<CoordinatesDto> GetDistrictCoordinatesAsync(int districtId);
        Task<Province?> FindProvinceByNameAsync(string provinceName);
        Task<District?> FindDistrictByNameAsync(string districtName);
    }
}
