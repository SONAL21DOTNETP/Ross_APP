public class Parts{

    public int Id { get; set; }
    public int PartNumber { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int UnitId { get; set; }
    public decimal GSTPercentage { get; set; }
    public int HSNDetailsId { get; set; }
    public required string SupplyType { get; set; }
    public decimal SellingPrice { get; set; }
    public decimal? Weight { get; set; }
    public string? Dimensions { get; set; }
    public int? PackingId { get; set; }
    public string? MaterialOfConstruction { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

}