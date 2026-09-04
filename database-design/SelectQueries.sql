
USE SportsBookingDB;

-- Facility Search (Members only - full details)
SELECT * FROM Facility
WHERE FacilityType = 'Tennis Court' AND FacilityAvailabilityStatus = 'Available';

-- Restricted Search (Guests only - limited details)
SELECT FacilityName, FacilityType, FacilityLocation, FacilityAvailabilityStatus FROM Facility
WHERE FacilityType = 'Tennis Court' AND FacilityAvailabilityStatus = 'Available';

-- Review Search (Guests and Members)
SELECT * FROM Review
WHERE Facility_FacilityID = 1;

-- Member Sign In verification (Members)
SELECT * FROM Member
WHERE MemberEmail = 'nimal@email.com' AND MemberPassword = 'password111';

-- Availability check before confirming a booking (Members)
SELECT * FROM Booking
WHERE Facility_FacilityID = 1 
AND BookingDate = '2026-09-10' 
AND Status IN ('Confirmed', 'Pending')
AND (StartTime < '10:00:00' AND EndTime > '09:00:00');


-- Member's booking history (Members)
SELECT * FROM Booking
WHERE Member_MemberID = 1;

-- Member checks their own booking status (Members)
SELECT BookingID, BookingDate, StartTime, EndTime, Status FROM Booking
WHERE Member_MemberID = 1 AND Status = 'Confirmed';

