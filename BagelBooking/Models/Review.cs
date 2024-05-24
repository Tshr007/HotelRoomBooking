using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagelBooking.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [ForeignKey("UserId")]

        //public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey("RoomId")]
        //public Room Room { get; set; }
        public int RoomId { get; set; }

        public string? Comment { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
