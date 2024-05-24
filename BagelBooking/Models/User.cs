using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagelBooking.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string User_name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Phone_No { get; set; }

        [Required]
        [EmailAddress]
        //[Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
