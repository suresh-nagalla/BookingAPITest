using BookingAPITest.API;
using BookingAPITest.Base;
using BookingAPITest.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BookingAPITest.Steps
{
    [Binding]
    public class CreateBookingSteps
    {
        private GlobalSettings _settings;
        public CreateBookingSteps(GlobalSettings settings) => _settings = settings;

        [Given(@"Given I perform POST operation to create new booking with following details")]
        public void GivenGivenIPerformPOSTOperationToCreateNewBookingWithFollowingDetails(Table table)
        {
            _settings.Response = Booking.PostBooking(Helper.GetBooking(table));
        }

        [Then(@"I Should see below newly created booking details")]
        public void ThenIShouldSeeBelowNewlyCreatedBookingDetails(Table table)
        {
            var response = Booking.GetPostBookingDetails(_settings.Response);
            var actualBookingDetails = response.ResponseData;
            var expectedBookingDetails = Helper.GetBooking(table);
            bool areDetailsMatching = actualBookingDetails.booking.Equals(expectedBookingDetails);
            Assert.IsTrue(response.IsSuccess, $"Failed to get the response. Response Code : {response.Message}");
            Assert.IsTrue(areDetailsMatching, "Actual Booking Details are not matching with Expected booking details");
        }
    }
}
