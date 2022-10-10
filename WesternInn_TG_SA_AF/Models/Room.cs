using System.ComponentModel.DataAnnotations;

namespace WesternInn_TG_SA_AF.Models
{
    public class Room
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[G123]{1}$")]
        public string Level { get; set; } = string.Empty;

        [RegularExpression(@"^[123]{1}$")]
        public int BedCount { get; set; }

        [Range(50, 300)]
        public decimal Price { get; set; }

        public ICollection<Booking>? TheBookings { get; set; }
    }
}
