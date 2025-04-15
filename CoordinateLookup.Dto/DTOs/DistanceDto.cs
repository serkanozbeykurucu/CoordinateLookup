using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateLookup.Dto.DTOs
{
    public class DistanceDto
    {
        public string FirstLocation { get; set; }
        public string SecondLocation { get; set; }
        public double DistanceInKm { get; set; }
    }
}
