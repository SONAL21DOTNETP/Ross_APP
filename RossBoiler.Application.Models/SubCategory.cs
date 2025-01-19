using System.ComponentModel.DataAnnotations.Schema;

namespace RossBoiler.Application.Models
{
    public class SubCategory
    {
        public int ID { get; set; }
       
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
