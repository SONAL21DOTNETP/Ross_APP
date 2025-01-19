using RossBoiler.Application.Models;

public class Customer
{
    public int Id { get; set; }
    public string OrgName { get; set; }
    public required string Description { get; set; }

    public ICollection<Address> Addresses { get; set; }
}