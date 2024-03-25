CREATE DATABASE NEXUS

USE NEXUS

--All database commad is here
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



CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY identity(1,1),
    Name VARCHAR(MAX),
    Email VARCHAR(MAX),
    Phone VARCHAR(20),
    Address NVARCHAR(MAX),
    AddressDetails VARCHAR(255),
    City VARCHAR(100),
    ServiceName VARCHAR(100),
    ZipCode VARCHAR(20)
);

CREATE TABLE DialUpConnection (
    ConnectionID INT PRIMARY KEY identity(1,1),
    CustomerID INT,
    PakageName VARCHAR(50) not null,
    Rates INT not null,
);

CREATE TABLE BroadbandConnection (
    ConnectionID INT PRIMARY KEY identity(1,1),
    CustomerID INT,
    PakageName VARCHAR(50) not null,
    Rates INT not null,
);

CREATE TABLE LandLineConnection (
    ConnectionID INT PRIMARY KEY identity(1,1),
    CustomerID INT not null,
    PakageName VARCHAR(50) not null,
    Rates INT not null,
);






--CREATE TABLE ServiceRequest(
--	Id int identity(1,1) primary key,
--	CutomarId int not null,
--	Name Email Phone Address1 Address2 ServiceName ZipCode   
--)




--ALL INSERT COMMAND IS HERE
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


--ALL THE SELECT QUERY IS HERE

select * from Customer
select * from CallCharges
Select *from ConnectionPlan
Select * from LandLineConnection




