/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO LeadStatuses (Id, Name) VALUES
(0, 'Invited'),
(1, 'Accepted'),
(2, 'Declined');

go

INSERT INTO Leads (FirstName, LastName, Status, DateCreated, Suburb, Category, Description, Price, Email, PhoneNumber)
VALUES 
('John', 'Doe', 0, GETDATE(), 'Brooklyn', 'Technology', 'Looking for web development services', 1000.00, 'john.doe@example.com', '555-1234'),
('Jane', 'Smith', 0, GETDATE(), 'Queens', 'Design', 'Interested in graphic design services', 750.00, 'jane.smith@example.com', '555-5678'),
('Michael', 'Brown', 0, GETDATE(), 'Manhattan', 'Marketing', 'Needs help with digital marketing strategy', 2000.00, 'michael.brown@example.com', '555-9876'),
('Emily', 'Davis', 0, GETDATE(), 'Brooklyn', 'Photography', 'Seeking photography services for an event', 500.00, 'emily.davis@example.com', '555-2468'),
('Robert', 'Johnson', 0, GETDATE(), 'Bronx', 'Legal', 'Looking for legal consultation', 1200.00, 'robert.johnson@example.com', '555-3579');