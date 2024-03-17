CREATE DATABASE NEXUS

USE NEXUS

--ALL BUSSNISS DATA START HERE
CREATE TABLE ConnectionType (
    ConnectionTypeId INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL
);

CREATE TABLE ConnectionPlan (
    ConnectionPlanId INT PRIMARY KEY,
    ConnectionTypeId INT,
    Name VARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    ValidityMonths INT,
    FOREIGN KEY (ConnectionTypeId) REFERENCES ConnectionType(ConnectionTypeId)
);

CREATE TABLE CallCharges (
    CallChargeId INT PRIMARY KEY,
    PlanId INT,
    CallType VARCHAR(100) NOT NULL,
    Charge DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (PlanId) REFERENCES ConnectionPlan(ConnectionPlanId)
);

--ALL BUSSNISS DATA START HERE



CREATE TABLE Customer(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(MAX) NOT NULL,
	LastName NVARCHAR(MAX) NULL,
	Email NVARCHAR(MAX) NOT NULL,
	[Password] NVARCHAR(MAX) NOT NULL,
	Address_1 NVARCHAR(MAX) NOT NULL,
	Address_2 NVARCHAR(MAX) NULL,
	PhoneNumber NVARCHAR(MAX) NOT NULL,
	City NVARCHAR(MAX) NOT NULL,
	ZipCode NVARCHAR(MAX) NOT NULL
)







--INSERT OF DATA IS START HERE

-- Connection Type
INSERT INTO ConnectionType (ConnectionTypeId, Name) VALUES
(1, 'Dial-Up'),
(2, 'Broadband'),
(3, 'Landline');

-- Connection Plan
INSERT INTO ConnectionPlan (ConnectionPlanId, ConnectionTypeId, Name, Price, ValidityMonths) VALUES
(1, 1, '10 Hrs.', 50.00, 1),
(2, 1, '30 Hrs.', 130.00, 3),
(3, 1, '60 Hrs.', 260.00, 6),
(4, 1, 'Unlimited 28Kbps - Monthly', 75.00, 1),
(5, 1, 'Unlimited 28Kbps - Quarterly', 150.00, 3)
-- Insert other plans for Dial-Up, Broadband, and Landline connections

-- Call Charges
INSERT INTO CallCharges (CallChargeId, PlanId, CallType, Charge) VALUES
(1, 1, 'Local', 0.55),  
(2, 1, 'STD', 2.25),     
(3, 1, 'Messaging For Mobiles', 1.00); 
