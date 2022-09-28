using System.ComponentModel.DataAnnotations;


namespace WesternInn_TG_SA_AF.Models
{
    public class Booking
    {

        [Key, Required]
        public int Id { get; set; }
    }
}
