
ALTER TABLE Inquiry ADD Facility_FacilityID INTEGER NULL;

ALTER TABLE Inquiry 
ADD CONSTRAINT Inquiry_Facility_FK FOREIGN KEY (Facility_FacilityID) 
REFERENCES Facility (FacilityID);


UPDATE Inquiry SET Facility_FacilityID = 2 WHERE InquiryID = 2; 
UPDATE Inquiry SET Facility_FacilityID = 7 WHERE InquiryID = 3; 
UPDATE Inquiry SET Facility_FacilityID = 6 WHERE InquiryID = 5; 