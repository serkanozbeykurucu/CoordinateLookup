using System.Text.Json;
using System.Globalization;
using CoordinateLookup.Data;
using CoordinateLookup.DTOs;
using CoordinateLookup.Business.Abstract;

namespace CoordinateLookup.Business.Concrete
{
    public class LocationSeederService : ILocationSeederService
    {
        private readonly CoordinateLookupDbContext _context;

        public LocationSeederService(CoordinateLookupDbContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            if (_context.Provinces.Any()) return;

            var jsonPath = Path.Combine(AppContext.BaseDirectory, "Data", "locations.json");
            if (!File.Exists(jsonPath))
            {
                throw new FileNotFoundException($"JSON file not found at path: {jsonPath}");
            }
            var json = await File.ReadAllTextAsync(jsonPath);

            var provinceDtos = JsonSerializer.Deserialize<List<ProvinceDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var provinces = provinceDtos.Select(dto => new Province
            {
                Name = dto.Province,
                PlateNumber = dto.PlateNumber,
                Coordinates = dto.Coordinates,
                Latitude = ParseLatitude(dto.Coordinates),
                Longitude = ParseLongitude(dto.Coordinates),
                Districts = dto.Districts.Select(d => new District
                {
                    Name = d.District,
                    Coordinates = d.Coordinates,
                    Latitude = ParseLatitude(d.Coordinates),
                    Longitude = ParseLongitude(d.Coordinates),
                    Towns = d.Towns.Select(t => new Town
                    {
                        Name = t.Town,
                        ZipCode = t.ZipCode,
                        Neighbourhoods = t.Neighbourhoods.Select(n => new Neighbourhood
                        {
                            Name = n.Name
                        }).ToList()
                    }).ToList()
                }).ToList()
            }).ToList();

            await _context.Provinces.AddRangeAsync(provinces);
            await _context.SaveChangesAsync();
        }
        private decimal ParseLatitude(string coordinates)
        {
            var split = coordinates.Split(',');
            if (split.Length > 0)
            {
                return decimal.Parse(split[0].Trim(), CultureInfo.InvariantCulture);  
            }
            return 0;
        }
        private decimal ParseLongitude(string coordinates)
        {
            var split = coordinates.Split(',');
            if (split.Length > 1)
            {
                return decimal.Parse(split[1].Trim(), CultureInfo.InvariantCulture);
            }
            return 0;
        }
    }
}
