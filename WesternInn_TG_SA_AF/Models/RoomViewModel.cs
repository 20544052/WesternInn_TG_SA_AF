using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WesternInn_TG_SA_AF.Models
{
    public class RoomViewModel
    {

        public int RoomId { get; set; }

        [RegularExpression(@"^[123]{1}$")]
        public int BedCount { get; set; }

        [DataType(DataType.Date)]
        public DateOnly CheckIn { get; set; }

        [DataType(DataType.Date)]
        public DateOnly CheckOut { get; set; }


    }
}
