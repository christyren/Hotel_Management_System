using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.ApplicationCore.Entitity
{
   public class Room
    {
        public int Id { get; set; }
        public int RTCode { get; set; }
        public byte Status { get; set; }
        public Roomtype Roomtype { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Roomservice> Roomservices { get; set; }
    }
}
