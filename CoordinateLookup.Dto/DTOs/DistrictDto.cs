
using System.Text.Json.Serialization;

namespace CoordinateLookup.DTOs
{
    public class DistrictDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string District { get; set; }
        public string Coordinates { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public List<TownDto> Towns { get; set; }
    }
}
