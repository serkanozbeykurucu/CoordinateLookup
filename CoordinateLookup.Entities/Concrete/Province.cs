public class Province
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PlateNumber { get; set; }
    public string Coordinates { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public ICollection<District> Districts { get; set; } = new List<District>();
}
