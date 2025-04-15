using CoordinateLookup.Dto.DTOs;

namespace CoordinateLookup.DTOs
{
    public class TownDto
    {
        public string Town { get; set; }
        public string ZipCode { get; set; }
        public List<NeighbourhoodDto> Neighbourhoods { get; set; }
    }
}
