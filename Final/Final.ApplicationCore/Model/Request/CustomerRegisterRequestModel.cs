using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.ApplicationCore.Model.Request
{
    public class CustomerRegisterRequestModel
    {
        [Required(ErrorMessage = "Room Number cannot be empty")]
        public int RoomNo { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string CName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone cannot be empty")]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Checkin { get; set; }

        [Required]
        public int TotalPersons { get; set; }

        [Required]
        public int BookingDays { get; set; }

        [Required]
        public decimal? Advance { get; set; }


    }
}
