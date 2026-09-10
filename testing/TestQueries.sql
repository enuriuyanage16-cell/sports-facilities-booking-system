

-- Test: Confirm new member registration inserted correctly

SELECT * FROM Member ORDER BY MemberID DESC;


-- Test: Confirm Sign In matches an existing member's credentials

SELECT * FROM Member WHERE MemberEmail = 'samidhi@email.com' AND MemberPassword = 'password555';



-- Test: Confirm a new booking and its matching payment were created together

SELECT * FROM Booking ORDER BY BookingID DESC;

SELECT * FROM Payment ORDER BY PaymentID DESC;

SELECT * FROM Booking WHERE Facility_FacilityID = 11 ORDER BY BookingID DESC;




-- Test: Confirm new review submission saved correctly

SELECT * FROM Review ORDER BY ReviewID DESC;


-- Test: Confirm Review Search returns correct reviews for a selected facility

SELECT * FROM Review WHERE Facility_FacilityID = 2 ORDER BY ReviewDate DESC;



-- Test: Confirm inquiries save correctly, both linked to a facility and general (NULL)

SELECT * FROM Inquiry ORDER BY InquiryID DESC;