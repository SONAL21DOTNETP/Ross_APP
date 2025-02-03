public class Unit
{
    public int ID { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string Description { get; set; }

    public required ICollection<Parts> Parts { get; set; }
}