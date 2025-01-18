using System.ComponentModel.DataAnnotations.Schema;

namespace RossBoiler.Application.Models
{
    public class SubCategory
    {
        public int ID { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public required string? Name { get; set; }
        public required string? Description { get; set; }

    }
}
