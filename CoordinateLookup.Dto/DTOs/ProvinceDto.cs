using System.Text.Json.Serialization;

namespace CoordinateLookup.DTOs
{
    public class ProvinceDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Province { get; set; }
        public int PlateNumber { get; set; }
        public string Coordinates { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public List<DistrictDto> Districts { get; set; }
    }
}
