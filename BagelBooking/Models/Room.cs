using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagelBooking.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        //[MaxLength(50)]
        public string RoomNumber { get; set; }

        [Required]
        //[MaxLength(100)]
        public string Type { get; set; }

        [Required]
        //[MaxLength(10)]
        public int Capacity { get; set; }


        [Required]
        public int Price { get; set; }


        public string? Amenities { get; set; }
        /*
        [Required]
        [Range(0, 1)]
        public int Availability { get; set; }
        */

        public string? ImgURL { get; set; }
    }
}
