using System.ComponentModel.DataAnnotations;

namespace WesternInn_TG_SA_AF.Models
{
    public class RoomBooking
    {
        [Required]
        [Range (1,16)]
        public int RoomID { get; set; }

        [Required]
        public string BookingA { get; set; } = string.Empty;

        [Required]
        public string BookingB { get; set; } = string.Empty;
    }
}
