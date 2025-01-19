public class Parts{

    public int Id { get; set; }
    public int PartNumber { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int UnitId { get; set; }
    public int GSTId { get; set; }
    public int HSNDetailsId { get; set; }
    public required string SupplyType { get; set; }
    public decimal SellingPrice { get; set; }
    public decimal? Weight { get; set; }
    public required string Dimensions { get; set; }
    public int? PackingId { get; set; }
    public required string MaterialOfConstruction { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

}