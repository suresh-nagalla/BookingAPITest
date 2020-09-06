using BookingAPITest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BookingAPITest.Util
{
  public class Helper
    {
        public static Model.BookingModel GetBooking(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            var checkinDate = (DateTime)data.checkin;
            var checkoutDate = (DateTime)data.checkout;

            //body
            var booking = new Model.BookingModel
            {
                firstname = (string)data.firstname,
                lastname = (string)data.lastname,
                totalprice = (int)data.totalprice,
                depositpaid = (bool)data.depositpaid,
                bookingdates = new Model.BookingDates()
                {

                    checkin =  new DateTime(checkinDate.Year, checkinDate.Month, checkinDate.Day),
                    checkout = new DateTime(checkoutDate.Year, checkoutDate.Month, checkoutDate.Day)
                }
            };
            return booking;
        }

        public static void GetCredentials()
        {
            
        }
    }
}
