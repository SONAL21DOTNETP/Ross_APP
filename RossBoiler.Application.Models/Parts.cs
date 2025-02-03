using System;
using System.ComponentModel.DataAnnotations.Schema;

public class Parts{

    public int Id { get; set; }
    public int PartNumber { get; set; }
    public required string Name { get; set; }
    public required string? Description { get; set; }
    public required string SupplyType { get; set; }
    public decimal SellingPrice { get; set; }
    public decimal? Weight { get; set; }
    public required string Dimensions { get; set; }
    public required string? MaterialOfConstruction { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public int UnitId { get; set; } 
    [ForeignKey("UnitId")]
    public required Unit Unit { get; set; }

    public int GSTId { get; set; }
    [ForeignKey("GSTId")]
    public required GST GST { get; set; }

    public int HSNDetailsId { get; set; }
    [ForeignKey("HSNDetailsId")]
    public required HSN HSN { get; set; }

    public int PackingId { get; set; }
    [ForeignKey("PackingId")]
    public required Packing Packing { get; set; }

}