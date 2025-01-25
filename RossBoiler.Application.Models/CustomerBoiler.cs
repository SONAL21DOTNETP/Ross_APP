using RossBoiler.Application.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class CustomerBoiler
{
    public int Id { get; set; }
    public required string BoilerHead { get; set; }
    public required string BoilerSeries { get; set; }

    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public required Customer Customer { get; set; }
}