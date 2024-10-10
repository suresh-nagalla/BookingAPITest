using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPITest.Base
{
  public  class GlobalSettings
    {
        public HttpResponseMessage Response { get; set; }
        public HttpRequestMessage Request { get; set; }
        public int BookingID { get; set; }
    }
}
