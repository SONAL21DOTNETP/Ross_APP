public class HSN
{
    public int ID { get; set; }
    public required string HsnCode { get; set; }
    public required string Description { get; set; }

    public required ICollection<Parts> Parts { get; set; }
}