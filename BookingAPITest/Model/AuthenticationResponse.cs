using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPITest.Model
{
    public class AuthenticationResponse
    {
        public int statusCode { get; set; }
        public string token { get; set; }
    }
}
