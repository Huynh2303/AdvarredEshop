using System.ComponentModel.DataAnnotations;

namespace abvancedEshop.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }
        [StringLength(150)]
        public string? CategoryName { get; set; }
        [StringLength(150)]
        public string? CategoryPhoto { get; set; }
        public int CategoryOder { get; set; }
    }
}
