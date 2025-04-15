public class Town
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ZipCode { get; set; }
    public int DistrictId { get; set; }
    public District District { get; set; }
    public ICollection<Neighbourhood> Neighbourhoods { get; set; } = new List<Neighbourhood>();
}
