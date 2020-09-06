using BookingAPITest.Base;
using BookingAPITest.Model;
using BookingAPITest.Util;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Booking = BookingAPITest.API.Booking;

namespace BookingAPITest.Steps
{
    [Binding]
    public class GetBookingSteps
    {
        private GlobalSettings _settings;
        public GetBookingSteps(GlobalSettings settings) => _settings = settings;

        [Given(@"I perform GET operation for all the bookings")]
        public void GivenIPerformGETOperationForAllTheBookings()
        {
            _settings.Response = Booking.GetAllBookingsResponse();
        }

        [Then(@"I should see get atleast one booking information in response")]
        public void ThenIShouldSeeGetAtleastOneBookingInformationInResponse()
        {
            Response<List<BookingID>> response = Booking.GetAllBookings(_settings.Response);
            Assert.IsTrue(response.IsSuccess, $"Failed to get the response. Response Code : {response.Message}");
            Assert.IsTrue(response.ResponseData.Count > 0, "No Bookings information found");
        }

        [Given(@"I perform GET operation for bookingid ""(.*)""")]
        public void GivenIPerformGETOperationForBookingid(int bookingID)
        {
            _settings.Response = Booking.GetBooking(bookingID);
        }


        [Given(@"I perform GET operation for Above Created Bookingid")]
        public void GivenIPerformGETOperationForAboveCreatedBookingid()
        {
            Response<Model.BookingResponse> response = Booking.GetPostBookingDetails(_settings.Response);
            _settings.Response = Booking.GetBooking(response.ResponseData.bookingid);
        }

        [Then(@"I Should see below booking details")]
        public void ThenIShouldSeeBelowBookingDetails(Table table)
        {
            var response = Booking.GetBookingDetails(_settings.Response);
            var actualBookingDetails = response.ResponseData;
            var expectedBookingDetails = Helper.GetBooking(table);
            //Response<Booking> response = Booking.GetBookingDetails(_settings.Response);
            Assert.IsTrue(response.IsSuccess, $"Failed to get the response. Response Code : {response.Message}");
            Assert.IsTrue(actualBookingDetails.Equals(expectedBookingDetails),
                $"Actual Booking Details are not matching with Expected booking details.updated : " +
                $"{ JsonConvert.SerializeObject(actualBookingDetails)} , " +
                $"Expected : { JsonConvert.SerializeObject(expectedBookingDetails)}");
        }

        [Then(@"I Should not see below booking details")]
        public void ThenIShouldNotSeeBelowBookingDetails(Table table)
        {
            var response = Booking.GetBookingDetails(_settings.Response);
            var actualBookingDetails = response?.ResponseData;
            var expectedBookingDetails = Helper.GetBooking(table);
            //Response<Booking> response = Booking.GetBookingDetails(_settings.Response);
            Assert.IsTrue(response.IsSuccess, $"Failed to get the response. Response Code : {response.Message}");
            Assert.IsFalse(actualBookingDetails.Equals(expectedBookingDetails), "Actual Booking Details are matching with Expected booking details which is not expected");
        }

        [Then(@"I Should not see  booking")]
        public void ThenIShouldNotSeeBooking()
        {
            var id = _settings.BookingID;
            var response = Booking.GetBooking(id);
            var responseVal = Booking.GetBookingDetails(response);
            Assert.IsTrue(!responseVal.IsSuccess);
        }

    }
}
