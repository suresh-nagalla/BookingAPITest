Feature: DeleteBookings
	Test DELETE Bookings scenarios

@smoke
Scenario: Create a booking and Delete the booking and verify No Booking found.
	Given Given I perform POST operation to create new booking with following details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   |
		| Suresh    | Nagalla  | 1000       | true        | 2020-09-01 | 2020-09-04 |
	And I Perform Delete Operation on the same Booking
	Then I Should not see  booking