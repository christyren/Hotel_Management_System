using Final.ApplicationCore.Entitity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.ApplicationCore.Model.Request
{
    public class RoomCreateRequestModel
    {
        [Required]
        public int RTCode { get; set; }

        [Required]
        public byte Status { get; set; }
    }
}
