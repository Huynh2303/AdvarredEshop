using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace abvancedEshop.Models
{
    public class Chechout
    {
        [Key]
        public int CheckoutId { get; set; }
        [Required]
        public string? ChechoutFirstName { get; set; }
        [Required]
        public string? ChechoutLastName { get; set; }
        [Required, EmailAddress]
        public string? ChechoutEmail { get; set; }
        [Required, Phone]
        public string ChechoutPhone { get; set; }
        [Required, StringLength(1000)]
        public string? AddressLine1 { get; set; }
        [Required, StringLength(1000)]
        public string? AddressLine2 { get; set; }
        [Required, StringLength(150)]
        public string? ChechoutCity { get; set; }
        [Required, StringLength(150), ForeignKey("ChechoutCountry")]
        public string? ChechoutCountry { get; set; }
        public Country? Country { get; set; }

        public string? State { get; set; }
        public int ZIpCode { get; set; }

        public bool CreateAnAccount { get; set; }
        public bool ShipToDifferentAddress { get; set; }


    }

}
