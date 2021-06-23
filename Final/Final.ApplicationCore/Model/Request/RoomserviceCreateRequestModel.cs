using Final.ApplicationCore.Entitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.ApplicationCore.Model.Request
{
   public class RoomserviceCreateRequestModel
    {
        public int RoomNo { get; set; }
        public string SDesc { get; set; }
        public decimal Amount { get; set; }
        public DateTime ServiceDate { get; set; }

    }
}
