public class GST
{
    public int ID { get; set; }
    public decimal Rate { get; set; } 
    public required string Description { get; set; }

    public required ICollection<Parts> Parts { get; set; }
}