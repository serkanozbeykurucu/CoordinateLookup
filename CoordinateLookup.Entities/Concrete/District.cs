public class District
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Coordinates { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public int ProvinceId { get; set; }
    public Province Province { get; set; }
    public ICollection<Town> Towns { get; set; } = new List<Town>();
}
