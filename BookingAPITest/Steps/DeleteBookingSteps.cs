using BookingAPITest.API;
using BookingAPITest.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BookingAPITest.Steps
{
    [Binding]
    public class DeleteBookingSteps
    {
        private GlobalSettings _settings;
        public DeleteBookingSteps(GlobalSettings settings) => _settings = settings;

        [Given(@"I Perform Delete Operation on the same Booking")]
        public void GivenIPerformDeleteOperationOnTheSameBooking()
        {
            var id = Booking.GetPostBookingDetails(_settings.Response).ResponseData.bookingid;
            _settings.Response = Booking.DeleteBooking(id);
            _settings.BookingID = id;
        }

    }
}
