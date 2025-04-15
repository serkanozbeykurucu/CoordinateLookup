using CoordinateLookup.Business.Abstract;
using CoordinateLookup.Business.Concrete;
using CoordinateLookup.Data.Abstract;
using CoordinateLookup.Data.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace CoordinateLookup.Business.DependencyResolvers.Microsoft
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILocationService, LocationService>();

            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IProvinceDal, EfProvinceDal>();

            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IDistrictDal, EfDistrictDal>();

            services.AddScoped<ITownService, TownService>();
            services.AddScoped<ITownDal, EfTownDal>();

            services.AddScoped<INeighbourhoodService, NeighbourhoodService>();
            services.AddScoped<INeighbourhoodDal, EfNeighbourhoodDal>();

            services.AddScoped<IDistanceService, DistanceService>();
            services.AddScoped<IDistanceDal, EfDistanceDal>();

            services.AddScoped<LocationSeederService>();
        }
    }
}
