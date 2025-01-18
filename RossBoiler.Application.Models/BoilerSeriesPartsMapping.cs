public class BoilerSeriesPartsMapping
{
    public int Id { get; set; }
    public required string Head { get; set; }
    public required int SeriesId { get; set; }
    public  string Description { get; set; }

    //comma separated 
    public required string DisplayAllParts { get; set; } 
}