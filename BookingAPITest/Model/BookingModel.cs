using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BookingAPITest.Model
{
    public class BookingModel
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public BookingDates bookingdates { get; set; }
        public string additionalneeds { get; set; }

        public override bool Equals(object obj)
        {
            BookingModel bookingVal = obj as Model.BookingModel;

            return (bookingVal != null)
                && (firstname.ToLower().Equals(bookingVal.firstname.ToLower(), StringComparison.OrdinalIgnoreCase))
                && (lastname.ToLower().Equals(bookingVal.lastname.ToLower(), StringComparison.OrdinalIgnoreCase))
                && (totalprice.Equals(bookingVal.totalprice))
                && (depositpaid.Equals(bookingVal.depositpaid))
                && (bookingdates.checkin == bookingVal.bookingdates.checkin && bookingdates.checkout == bookingVal.bookingdates.checkout);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class BookingDates
    {
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }
    }
}
