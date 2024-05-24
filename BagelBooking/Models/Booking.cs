using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagelBooking.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int UserId { get; set; }

        [Required]
        public int No_Of_Rooms { get; set; }

        [ForeignKey("RoomId")]
        public int RoomId { get; set; }

        //public Room Room { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }
        /*
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }
        */
        

        [ForeignKey("UserId")]
        //public User User { get; set; }
        /* 
        public string Status { get; set; }
        */
     
        [MaxLength(50)]
        public string PaymentStatus { get; set; }
    }
}
