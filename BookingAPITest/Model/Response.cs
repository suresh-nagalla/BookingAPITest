using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPITest.Model
{
   public class Response<T> where T:  class, new()
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T ResponseData { get; set; }
    }
}
