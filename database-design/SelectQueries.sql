

-- 1. Facility Search (Members only - full details, search by facility type, date and time)
SELECT * FROM Facility
WHERE FacilityType LIKE '%Tennis%' 
AND FacilityAvailabilityStatus = 'Available'
AND FacilityID NOT IN (
    SELECT Facility_FacilityID FROM Booking
    WHERE BookingDate = '2026-09-10'
    AND Status IN ('Confirmed', 'Pending')
    AND (StartTime < '10:00:00' AND EndTime > '09:00:00')
);


-- 2. Restricted Search (Guests only - limited details, search by type, date and time)
SELECT FacilityName, FacilityType, FacilityLocation, FacilityAvailabilityStatus FROM Facility
WHERE FacilityType LIKE '%Tennis%' 
AND FacilityAvailabilityStatus = 'Available'
AND FacilityID NOT IN (
    SELECT Facility_FacilityID FROM Booking
    WHERE BookingDate = '2026-09-10'
    AND Status IN ('Confirmed', 'Pending')
    AND (StartTime < '10:00:00' AND EndTime > '09:00:00')
);


-- 3. Review Search by Facility (Guests and Members)
SELECT * FROM Review
WHERE Facility_FacilityID = 1;


-- 4. Member Sign In verification (Members)
SELECT * FROM Member
WHERE MemberEmail = 'nimal@email.com' AND MemberPassword = 'password111';


-- 5. Availability check before confirming a booking (Members)
SELECT * FROM Booking
WHERE Facility_FacilityID = 1 
AND BookingDate = '2026-09-10' 
AND Status IN ('Confirmed', 'Pending')
AND (StartTime < '10:00:00' AND EndTime > '09:00:00');


-- 6. Member's booking history (Members)
SELECT * FROM Booking
WHERE Member_MemberID = 1;


-- 7. Member checks their own booking status (Members)
SELECT BookingID, BookingDate, StartTime, EndTime, Status FROM Booking
WHERE Member_MemberID = 1 AND Status = 'Confirmed';


-- 8. Facilities with reviews rated above 3 (Members and Guests)
SELECT Facility.FacilityName, Review.Rating, Review.Comment 
FROM Facility 
JOIN Review ON Facility.FacilityID = Review.Facility_FacilityID 
WHERE Review.Rating > 3;


-- 9. Average rating for a specific Facility (Members and Guests)
SELECT Facility_FacilityID, AVG(Rating) AS AverageRating 
FROM Review 
WHERE Facility_FacilityID = 1 
GROUP BY Facility_FacilityID;
