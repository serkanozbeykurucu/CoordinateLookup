using CoordinateLookup.DTOs;
using CoordinateLookup.Shared.Common.Utilities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateLookup.Business.Abstract
{
    public interface IProvinceService
    {
        Task<Response<List<Province>>> GetAllProvincesAsync();
        Task<Response<ProvinceDto?>> GetProvinceByIdAsync(int provinceId);
        Task<Response<ProvinceDto?>> GetProvinceWithDistrictsAsync(int provinceId);
    }
}
