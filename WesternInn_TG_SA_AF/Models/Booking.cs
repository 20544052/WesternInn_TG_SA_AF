using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;

namespace WesternInn_TG_SA_AF.Models
{
    public class Booking
    {
        //Primary Key
        [Key, Required]
        public int Id { get; set; }

        //Foreign Key
        public int RoomId { get; set; }

        //Foreign Key
        [Required]
        [DataType(DataType.EmailAddress)]
        public string GuestEmail { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        [Range(0, 10000.0)]
        public decimal Cost { get; set; }

        [Display(Name = "The Room")]
        public Room? TheRoom { get; set; }

        [Display(Name = "The Guest")]
        public Guest? TheGuest { get; set; }
    }
}