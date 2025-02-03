using RossBoiler.Application.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Address
{
    public int Id { get; set; }
    
    public required string Area { get; set; }
    public required string City { get; set; }
    public required string Pincode { get; set; }
    public required string State { get; set; }

    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public Customer? Customer { get; set; }
}