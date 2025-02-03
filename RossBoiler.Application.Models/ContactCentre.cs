using RossBoiler.Application.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class ContactCentre
{
    public int Id { get; set; }
    public required string POC { get; set; } 
    public required string PhoneNumber1 { get; set; }
    public required string PhoneNumber2 { get; set; }
    public required string PhoneNumber3 { get; set; }

    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public required Customer Customer { get; set; }
}