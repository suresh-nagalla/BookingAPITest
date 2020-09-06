Feature: CreateBookings
	Test POST Bookings scenarios

@smoke
Scenario: Create a booking and verify its details
	Given Given I perform POST operation to create new booking with following details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   |
		| Suresh    | Nagalla  | 1000       | true        | 2020-09-01 | 2020-09-04 |
	Then I Should see below newly created booking details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   |
		| Suresh    | Nagalla  | 1000       | true        | 2020-09-01 | 2020-09-04 |