using System.ComponentModel.DataAnnotations;

namespace abvancedEshop.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required, StringLength(150)]
        public string CountryName { get; set; }
    }
}
