Feature: UpdateBookings
	Test PUT Bookings scenarios

@smoke
Scenario: Update an existing booking and verify its details
	Given Given I perform POST operation to create new booking with following details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   |
		| Suresh    | Nagalla  | 1000       | true        | 2020-09-01 | 2020-09-04 |
	And I perform PUT operation to update the booking details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   |
		| Suresh    | Nagalla  | 2000       | true        | 2020-09-01 | 2020-09-04 |
	Then I Should see below newly updated booking details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   |
		| Suresh    | Nagalla | 2000       | true        | 2020-09-01 | 2020-09-04 |