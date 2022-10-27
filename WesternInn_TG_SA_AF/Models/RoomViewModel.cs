using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WesternInn_TG_SA_AF.Models
{
    public class RoomViewModel
    {

        public int RoomId { get; set; }

        [RegularExpression(@"^[123]{1}$")]
        public int BedCount { get; set; }

        public DateOnly CheckIn { get; set; }
        public DateOnly CheckOut { get; set; }


    }
}
