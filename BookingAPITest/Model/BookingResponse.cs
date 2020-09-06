using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPITest.Model
{
   public class BookingResponse
    {
        public int bookingid { get; set; }
        public BookingModel booking { get; set; }
    }
}
