public class Currency
{
    public int CurrencyId { get; set; }
    public required string? CurrencyName { get; set; }
    public int Code { get; set; }
    public required decimal Rate { get; set; }
    public required string? Description { get; set; }
}


