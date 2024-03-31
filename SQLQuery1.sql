CREATE DATABASE NEXUS

USE NEXUS

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

create table Register(
	Id int primary key identity(1,1) ,
	UserName varchar(50),
	Email varchar(50),
	[Password] varchar(50)
)
Select * from Register
Select * from DialUpConnection
select * from Customer
select * from BroadbandConnection



