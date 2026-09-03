
INSERT INTO Member (MemberID, MemberName, MemberPhoneNumber, MemberEmail, MemberAddress, MemberPassword, MemberPreferredSports, DateRegistered)
VALUES 
(1, 'Nimal Perera', '0771234567', 'nimal@email.com', '123 Galle Road, Colombo', 'password111', 'Tennis', '2026-01-15'),
(2, 'Ananda Jayawardana', '0779312045', 'ananda@email.com', '54 Circular Road, Galle', 'password222', 'Soccer', '2026-02-01'),
(3, 'Nilmini Paranagama', '0775791346', 'nilmini@email.com', '143 Sardhapura-kanniya Road, Trincomalee', 'password333', 'Swimming', '2026-02-11'),
(4, 'Roshan Bandara', '0770653007', 'roshan@email.com', '21 Siri Sumana Road, Colombo', 'password444', 'Boxing', '2026-02-28'),
(5, 'Samidhi Liyanage', '0771649582', 'samidhi@email.com', '12 Haragama Road, Kandy', 'password555', 'Basketball', '2026-03-20');


INSERT INTO Member (MemberID, MemberName, MemberPhoneNumber, MemberEmail, MemberAddress, MemberPassword, MemberPreferredSports, DateRegistered)
VALUES 
(6, 'Chathurika Wijesinghe', '0772345678', 'chathurika@email.com', '45 Temple Road, Nugegoda', 'password666', 'Swimming', '2026-03-25'),
(7, 'Dinesh Kumara', '0773456789', 'dinesh@email.com', '78 Station Road, Matara', 'password777', 'Swimming', '2026-04-02'),
(8, 'Ishara Fernando', '0774567890', 'ishara@email.com', '19 Lake Road, Kurunegala', 'password888', 'Tennis', '2026-04-10'),
(9, 'Kasun Rathnayake', '0775678901', 'kasun@email.com', '33 Beach Road, Negombo', 'password999', 'Soccer', '2026-04-18'),
(10, 'Malsha Gunawardana', '0776789012', 'malsha@email.com', '67 Hill Street, Nuwara Eliya', 'password1010', 'Basketball', '2026-04-25');


INSERT INTO Facility (FacilityID, FacilityName, FacilityType, FacilityLocation, FacilityCapacity, FacilityAvailabilityStatus, StatusReason, Description, OpeningTime, ClosingTime)
VALUES
(1, 'Sugathadasa Tennis Court 1', 'Tennis Court', 'Sugathadasa Stadium, Colombo', 4, 'Available', NULL, 'A well-maintained outdoor court, popular for evening matches thanks to good floodlighting.', '08:00:00', '22:00:00'),
(2, 'Galle Face Green Soccer Pitch', 'Soccer Field', 'Galle Face Green, Colombo', 22, 'Available', NULL, 'A spacious seaside field with a relaxed, open-air atmosphere, ideal for casual and competitive matches alike.', '06:00:00', '20:00:00'),
(3, 'Kandy Municipal Basketball Court', 'Basketball Court', 'Kandy Municipal Council Grounds, Kandy', 10, 'Available', NULL, 'An indoor court with proper wooden flooring, well-suited for regular league play.', '07:00:00', '21:00:00'),
(4, 'Trincomalee Sports Complex Court', 'Tennis Court', 'Trincomalee Sports Complex, Trincomalee', 4, 'Closed', 'Under maintenance', 'A standard outdoor court currently undergoing surface repairs.', '08:00:00', '22:00:00'),
(5, 'Negombo Public Grounds Field', 'Soccer Field', 'Negombo Public Grounds, Negombo', 22, 'Available', NULL, 'A community favourite with good floodlighting, often used for evening matches.', '06:00:00', '22:00:00'),
(6, 'Otters Aquatic Pool', 'Swimming Pool', 'Otters Aquatic Club, Colombo', 30, 'Available', NULL, 'A full-length competition pool with dedicated lanes for both training and casual swimming.', '06:00:00', '20:00:00'),
(7, 'Sugathadasa Boxing Arena', 'Boxing Ring', 'Sugathadasa Stadium, Colombo', 15, 'Available', NULL, 'A properly equipped indoor ring with training gear, used for both sparring sessions and amateur bouts.', '07:00:00', '21:00:00');


INSERT INTO Booking (BookingID, BookingDate, StartTime, EndTime, Status, Member_MemberID, Facility_FacilityID)
VALUES 
(1, '2026-09-10', '09:00:00', '10:00:00', 'Confirmed', 1, 1),
(2, '2026-09-11', '17:00:00', '18:00:00', 'Confirmed', 3, 2),
(3, '2026-09-12', '19:00:00', '20:00:00', 'Pending', 6, 6),
(4, '2026-09-13', '08:00:00', '09:00:00', 'Confirmed', 7, 7),
(5, '2026-09-14', '15:00:00', '16:00:00', 'Cancelled', 9, 5);


INSERT INTO Review (ReviewID, Rating, Comment, ReviewDate, Member_MemberID, Facility_FacilityID)
VALUES 
(1, 5, 'Great court, well maintained and the lighting was perfect for our evening match.', '2026-09-11', 1, 1),
(2, 4, 'Good pitch overall, though it could use a bit more grass upkeep near the goal areas.', '2026-09-12', 3, 2),
(3, 4, 'Solid training space, staff were helpful in setting up the ring.', '2026-09-14', 7, 7);


INSERT INTO Inquiry (InquiryID, Name, Email, ContactNo, InquiryMessage, InquiryDate)
VALUES 
(1, 'Tharindu Silva', 'tharindu@email.com', '0771122334', 'Hi, could you let me know the membership fees for joining the sports council?', '2026-09-05'),
(2, 'Anusha Perera', 'anusha@email.com', '0772233445', 'Is the Galle Face Green soccer pitch available for a birthday event this weekend?', '2026-09-06'),
(3, 'Ruwan Jayasuriya', 'ruwan@email.com', '0773344556', 'Do you offer any group discounts for booking multiple sessions at the boxing arena?', '2026-09-07'),
(4, 'Nadeesha Weerasinghe', 'nadeesha@email.com', '0774455667', 'What documents do I need to bring when registering as a new member?', '2026-09-08'),
(5, 'Chamal Rodrigo', 'chamal@email.com', '0775566778', 'Can guests use the swimming pool without becoming a member first?', '2026-09-09');