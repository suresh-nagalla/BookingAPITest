Feature: GetBookings
	Test GET Bookings scenarios

@smoke
Scenario: Verify all the booking ids in the bookings API
	Given I perform GET operation for all the bookings
	Then I should see get atleast one booking information in response

@smoke
Scenario: Get the Booking for the created booking and verify its details
	Given Given I perform POST operation to create new booking with following details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   |
		| Suresh      | Nagalla    | 1000        | true       | 2020-09-01 | 2020-09-04 |
	And I perform GET operation for Above Created Bookingid
	Then I Should see below booking details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   |
		| Suresh      | Nagalla    | 1000        | true       | 2020-09-01 | 2020-09-04 |

@smoke
Scenario: Get the Booking for the given booking id and verify its details
	Given I perform GET operation for bookingid "6"
	Then I Should see below booking details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   |
		| Eric		| Brown      | 770    | true       | 2017-03-29 | 2020-01-13 |   

@GetNegativeScenarios
Scenario: Get the Booking for the given booking id and provide wrong details to test negative scenario
	Given I perform GET operation for bookingid "6"
	Then I Should not see below booking details
		| firstname | lastname | totalprice | depositpaid | checkin    | checkout   |
		| Susan		| Ericsson      | 264    | true       | 2019-10-24 | 2020-03-25 |   
