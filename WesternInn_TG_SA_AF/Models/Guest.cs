using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WesternInn_TG_SA_AF.Models
{
    public class Guest
    {
        [Key,Required,DatabaseGenerated(DatabaseGeneratedOption.None), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Must start with a capital letter and continue with 1-19 letters, a hyphen or apostrophe")]
        [ StringLength(20, MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z'-]{1,19}$")]
        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Must start with a capital letter and continue with 1-19 letters, a hyphen or apostrophe")]
        [StringLength(20, MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z'-]{1,19}$")]
        [Display(Name = "Given Name")]
        public string GivenName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Residential postcode ranges only"), DataType(DataType.PostalCode), Display(Name = "Post Code")]
        // Regex contains all Australian Residential post code sequences.
        // PO Boxes and Large Volume Receivers (LVRs) have been excluded.
        [RegularExpression(@"(0[89][0-9]{2})|([34][0-9]{3})|(5[0-7][0-9]{2})|(6[0-7][0-9][0-7])|(2[0-9]{3})|(7[0-7][0-9]{2})", ErrorMessage = "Residential postcode ranges only")]
        public string PostCode { get; set; } = string.Empty;

        public ICollection<Booking>? TheBookings { get; set; }

    }
}
