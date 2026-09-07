
-- 1. Member
INSERT INTO Member (MemberID, MemberName, MemberPhoneNumber, MemberEmail, MemberAddress, MemberPassword, DateRegistered)
VALUES 
(1, 'Nimal Perera', '0771234567', 'nimal@email.com', '123 Galle Road, Colombo', 'password111', '2026-01-15'),
(2, 'Ananda Jayawardana', '0779312045', 'ananda@email.com', '54 Circular Road, Galle', 'password222', '2026-02-01'),
(3, 'Nilmini Paranagama', '0775791346', 'nilmini@email.com', '143 Sardhapura-kanniya Road, Trincomalee', 'password333', '2026-02-11'),
(4, 'Roshan Bandara', '0770653007', 'roshan@email.com', '21 Siri Sumana Road, Colombo', 'password444', '2026-02-28'),
(5, 'Samidhi Liyanage', '0771649582', 'samidhi@email.com', '12 Haragama Road, Kandy', 'password555', '2026-03-20'),
(6, 'Chathurika Wijesinghe', '0772345678', 'chathurika@email.com', '45 Temple Road, Nugegoda', 'password666', '2026-03-25'),
(7, 'Dinesh Kumara', '0773456789', 'dinesh@email.com', '78 Station Road, Matara', 'password777', '2026-04-02'),
(8, 'Ishara Fernando', '0774567890', 'ishara@email.com', '19 Lake Road, Kurunegala', 'password888', '2026-04-10'),
(9, 'Kasun Rathnayake', '0775678901', 'kasun@email.com', '33 Beach Road, Negombo', 'password999', '2026-04-18'),
(10, 'Malsha Gunawardana', '0776789012', 'malsha@email.com', '67 Hill Street, Nuwara Eliya', 'password1010', '2026-04-25');


-- 2. Facility 
INSERT INTO Facility (FacilityID, FacilityName, FacilityType, FacilityLocation, FacilityCapacity, FacilityAvailabilityStatus, StatusReason, Description, OpeningTime, ClosingTime)
VALUES
(1, 'Sugathadasa Tennis Court 1', 'Tennis Court', 'Sugathadasa Stadium, Colombo', 4, 'Available', NULL, 'A well-maintained outdoor court, popular for evening matches thanks to good floodlighting.', '08:00:00', '22:00:00'),
(2, 'Galle Face Green Soccer Pitch', 'Soccer Field', 'Galle Face Green, Colombo', 22, 'Available', NULL, 'A spacious seaside field with a relaxed, open-air atmosphere, ideal for casual and competitive matches alike.', '06:00:00', '20:00:00'),
(3, 'Kandy Municipal Basketball Court', 'Basketball Court', 'Kandy Municipal Council Grounds, Kandy', 10, 'Available', NULL, 'An indoor court with proper wooden flooring, well-suited for regular league play.', '07:00:00', '21:00:00'),
(4, 'Trincomalee Sports Complex Court', 'Tennis Court', 'Trincomalee Sports Complex, Trincomalee', 4, 'Closed', 'Under maintenance', 'A standard outdoor court currently undergoing surface repairs.', '08:00:00', '22:00:00'),
(5, 'Negombo Public Grounds Field', 'Soccer Field', 'Negombo Public Grounds, Negombo', 22, 'Available', NULL, 'A community favourite with good floodlighting, often used for evening matches.', '06:00:00', '22:00:00'),
(6, 'Otters Aquatic Pool', 'Swimming Pool', 'Otters Aquatic Club, Colombo', 30, 'Available', NULL, 'A full-length competition pool with dedicated lanes for both training and casual swimming.', '06:00:00', '20:00:00'),
(7, 'Sugathadasa Boxing Arena', 'Boxing Ring', 'Sugathadasa Stadium, Colombo', 15, 'Available', NULL, 'A properly equipped indoor ring with training gear, used for both sparring sessions and amateur bouts.', '07:00:00', '21:00:00'),
(8, 'Colombo Race Course Basketball Court', 'Basketball Court', 'Colombo Race Course, Colombo', 10, 'Available', NULL, 'A popular outdoor court in a central location, well used by local leagues.', '07:00:00', '21:00:00'),
(9, 'Kandy Bogambara Swimming Pool', 'Swimming Pool', 'Bogambara, Kandy', 25, 'Available', NULL, 'A public pool with dedicated lanes, good for both casual swimmers and training groups.', '06:00:00', '19:00:00'),
(10, 'Matara Sports Complex Soccer Field', 'Soccer Field', 'Matara Sports Complex, Matara', 22, 'Available', NULL, 'A full-size field with good floodlighting for evening matches.', '06:00:00', '21:00:00'),
(11, 'Kurunegala Community Tennis Court', 'Tennis Court', 'Kurunegala Community Grounds, Kurunegala', 4, 'Available', NULL, 'A simple, well-kept outdoor court popular with local players.', '08:00:00', '20:00:00'),
(12, 'Negombo Boxing Gym', 'Boxing Ring', 'Negombo Sports Centre, Negombo', 12, 'Available', NULL, 'A compact indoor training space with a full ring and basic equipment.', '07:00:00', '20:00:00');


-- 3. Sport
INSERT INTO Sport (SportID, SportName)
VALUES
(1, 'Tennis'),
(2, 'Soccer'),
(3, 'Swimming'),
(4, 'Boxing'),
(5, 'Basketball');


-- 4. Amenity
INSERT INTO Amenity (AmenityID, AmenityName)
VALUES
(1, 'Parking'),
(2, 'Changing Rooms'),
(3, 'Showers'),
(4, 'Floodlights'),
(5, 'Equipment Rental');


-- 5. Booking 
INSERT INTO Booking (BookingID, BookingDate, StartTime, EndTime, Status, Member_MemberID, Facility_FacilityID)
VALUES 
(1, '2026-09-10', '09:00:00', '10:00:00', 'Confirmed', 1, 1),
(2, '2026-09-11', '17:00:00', '18:00:00', 'Confirmed', 3, 2),
(3, '2026-09-12', '19:00:00', '20:00:00', 'Pending', 6, 6),
(4, '2026-09-13', '08:00:00', '09:00:00', 'Confirmed', 7, 7),
(5, '2026-09-14', '15:00:00', '16:00:00', 'Cancelled', 9, 5),
(6, '2026-09-15', '10:00:00', '11:00:00', 'Confirmed', 2, 2),
(7, '2026-09-16', '18:00:00', '19:00:00', 'Confirmed', 4, 7),
(8, '2026-09-17', '07:00:00', '08:00:00', 'Confirmed', 5, 3),
(9, '2026-09-18', '16:00:00', '17:00:00', 'Confirmed', 8, 1),
(10, '2026-09-19', '09:00:00', '10:00:00', 'Confirmed', 10, 3),
(11, '2026-09-20', '14:00:00', '15:00:00', 'Pending', 1, 6),
(12, '2026-09-21', '11:00:00', '12:00:00', 'Confirmed', 3, 6),
(13, '2026-09-22', '17:00:00', '18:00:00', 'Cancelled', 6, 2),
(14, '2026-09-23', '08:00:00', '09:00:00', 'Confirmed', 9, 1),
(15, '2026-09-24', '19:00:00', '20:00:00', 'Confirmed', 7, 6),
(16, '2026-09-25', '09:00:00', '10:00:00', 'Confirmed', 2, 10),
(17, '2026-09-26', '07:00:00', '08:00:00', 'Confirmed', 5, 8),
(18, '2026-09-27', '10:00:00', '11:00:00', 'Confirmed', 10, 9),
(19, '2026-09-28', '16:00:00', '17:00:00', 'Pending', 4, 12),
(20, '2026-09-29', '08:00:00', '09:00:00', 'Confirmed', 8, 11);


-- 6. Review 
INSERT INTO Review (ReviewID, Rating, Comment, ReviewDate, Member_MemberID, Facility_FacilityID)
VALUES 
(1, 5, 'Great court, well maintained and the lighting was perfect for our evening match.', '2026-09-11', 1, 1),
(2, 4, 'Good pitch overall, though it could use a bit more grass upkeep near the goal areas.', '2026-09-12', 3, 2),
(3, 4, 'Solid training space, staff were helpful in setting up the ring.', '2026-09-14', 7, 7),
(4, 5, 'Loved the seaside atmosphere, will definitely book again.', '2026-09-16', 2, 2),
(5, 5, 'Excellent equipment and a proper professional setup.', '2026-09-17', 4, 7),
(6, 4, 'Good indoor court, floor was clean and well marked.', '2026-09-18', 5, 3),
(7, 5, 'Court was in great shape, will be back for more matches.', '2026-09-19', 8, 1),
(8, 3, 'Decent court but got a bit crowded in the evening.', '2026-09-20', 10, 3),
(9, 4, 'Pool was clean and well-lit, staff were friendly.', '2026-09-22', 3, 6),
(10, 5, 'Best court in the area, highly recommend for tennis players.', '2026-09-24', 9, 1),
(11, 4, 'Field was in decent shape, good for a weekend match.', '2026-09-26', 2, 10),
(12, 5, 'Pool was spacious and well-maintained, great for training sessions.', '2026-09-28', 10, 9);


-- 7. Payment 
INSERT INTO Payment (PaymentID, Amount, PaymentDate, PaymentMethod, PaymentStatus, Booking_BookingID)
VALUES
(1, 2000.00, '2026-09-10', 'Card', 'Paid', 1),
(2, 4000.00, '2026-09-11', 'Online Transfer', 'Paid', 2),
(3, 2000.00, '2026-09-13', 'Card', 'Paid', 4),
(4, 4000.00, '2026-09-14', 'Online Transfer', 'Refunded', 5),
(5, 4000.00, '2026-09-15', 'Card', 'Paid', 6),
(6, 2000.00, '2026-09-16', 'Online Transfer', 'Paid', 7),
(7, 2500.00, '2026-09-17', 'Card', 'Paid', 8),
(8, 2000.00, '2026-09-18', 'Card', 'Paid', 9),
(9, 2500.00, '2026-09-19', 'Online Transfer', 'Paid', 10),
(10, 1500.00, '2026-09-21', 'Card', 'Paid', 12),
(11, 4000.00, '2026-09-22', 'Online Transfer', 'Refunded', 13),
(12, 2000.00, '2026-09-23', 'Card', 'Paid', 14),
(13, 1500.00, '2026-09-24', 'Online Transfer', 'Paid', 15),
(14, 4000.00, '2026-09-25', 'Card', 'Paid', 16),
(15, 2500.00, '2026-09-26', 'Online Transfer', 'Paid', 17),
(16, 1500.00, '2026-09-27', 'Card', 'Paid', 18),
(17, 2000.00, '2026-09-29', 'Online Transfer', 'Paid', 20);


-- 8. Inquiry
INSERT INTO Inquiry (InquiryID, Name, Email, ContactNo, InquiryMessage, InquiryDate)
VALUES 
(1, 'Tharindu Silva', 'tharindu@email.com', '0771122334', 'Hi, could you let me know the membership fees for joining the sports council?', '2026-09-05'),
(2, 'Anusha Perera', 'anusha@email.com', '0772233445', 'Is the Galle Face Green soccer pitch available for a birthday event this weekend?', '2026-09-06'),
(3, 'Ruwan Jayasuriya', 'ruwan@email.com', '0773344556', 'Do you offer any group discounts for booking multiple sessions at the boxing arena?', '2026-09-07'),
(4, 'Nadeesha Weerasinghe', 'nadeesha@email.com', '0774455667', 'What documents do I need to bring when registering as a new member?', '2026-09-08'),
(5, 'Chamal Rodrigo', 'chamal@email.com', '0775566778', 'Can guests use the swimming pool without becoming a member first?', '2026-09-09'),
(6, 'Sanduni Ekanayake', 'sanduni@email.com', '0776677889', 'Do you have a court available for a corporate tournament next month?', '2026-09-10'),
(7, 'Lahiru Madushanka', 'lahiru@email.com', '0777788990', 'What is the process for cancelling a confirmed booking?', '2026-09-11');


-- 9. MemberSports
INSERT INTO MemberSports (Member_MemberID, Sport_SportID)
VALUES
(1, 1), 
(1, 2),
(2, 2),
(3, 3), 
(3, 5),
(4, 4),
(5, 5),
(6, 3),
(7, 3), 
(7, 1),
(8, 1),
(9, 2), 
(9, 3),
(10, 5);


-- 10. FacilitySport
INSERT INTO FacilitySport (Facility_FacilityID, Sport_SportID)
VALUES
(1, 1),
(2, 2),
(3, 5),
(4, 1),
(5, 2),
(6, 3),
(7, 4),
(8, 5),
(9, 3),
(10, 2),
(11, 1),
(12, 4);


-- 11. FacilityAmenity
INSERT INTO FacilityAmenity (Facility_FacilityID, Amenity_AmenityID)
VALUES
(1, 1), 
(1, 4),
(2, 1), 
(2, 2),
(3, 1), 
(3, 2), 
(3, 3),
(4, 1),
(5, 1), 
(5, 4),
(6, 2), 
(6, 3), 
(6, 5),
(7, 2), 
(7, 3), 
(7, 5),
(8, 1), 
(8, 2),
(9, 2), 
(9, 3), 
(9, 5),
(10, 1), 
(10, 4),
(11, 1),
(12, 2), 
(12, 3), 
(12, 5);