using RossBoiler.Application.Models;

public class Packing
{
    public int ID { get; set; }
    public required string Name { get; set; }
    public required string UsedFor { get; set; }
    public required string Description { get; set; }
    public required ICollection<Parts> Parts { get; set; }
}