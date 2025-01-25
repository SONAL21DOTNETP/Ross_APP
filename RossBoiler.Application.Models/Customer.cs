using RossBoiler.Application.Models;

public class Customer
{
    public int Id { get; set; }
    public required string OrgName { get; set; }
    public required string Description { get; set; }

    public required ICollection<Address> Addresses { get; set; }

    public required ICollection<ContactCentre> ContactCentres { get; set; }

    public required ICollection<CustomerBoiler> CustomerBoilers { get; set; }
    
}