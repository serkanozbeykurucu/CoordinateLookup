using AspNetCoreRateLimit;
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
            // Rate Limiting Configuration start
            
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            
            // Rate Limiting Configuration end
            
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
