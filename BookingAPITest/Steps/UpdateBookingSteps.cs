using BookingAPITest.API;
using BookingAPITest.Base;
using BookingAPITest.Util;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BookingAPITest.Steps
{
    [Binding]
    public class UpdateBookingSteps
    {
        private GlobalSettings _settings;
        public UpdateBookingSteps(GlobalSettings settings) => _settings = settings;

        [Given(@"I perform PUT operation to update the booking details")]
        public void GivenIPerformPUTOperationToUpdateTheBookingDetails(Table table)
        {
            var response = Booking.GetPostBookingDetails(_settings.Response);
            var data = Helper.GetBooking(table);
            var updatedResponse = Booking.UpdateBooking(data,response.ResponseData.bookingid);
            _settings.Response = updatedResponse;
        }

        [Then(@"I Should see below newly updated booking details")]
        public void ThenIShouldSeeBelowNewlyUpdatedBookingDetails(Table table)
        {
            var updatedDetails = Booking.GetUpdatedBookingDetails(_settings.Response);
            var expectedDetails = Helper.GetBooking(table);
            var isUpdated = updatedDetails.ResponseData.Equals(expectedDetails);
            Assert.IsTrue(isUpdated, $"updated Booking Details are not matching with expected booking details. updated : { JsonConvert.SerializeObject(updatedDetails.ResponseData)} , Expected : { JsonConvert.SerializeObject(expectedDetails)}");
        }

    }
}
