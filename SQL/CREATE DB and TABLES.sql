-- Final Project SQL script

-- Create database BookingSystem 
USE master
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'BookingSystem')
  BEGIN	
	DROP DATABASE BookingSystem
    CREATE DATABASE BookingSystem
   END
   ELSE CREATE DATABASE BookingSystem
    GO
       USE BookingSystem
    GO
-- DATABASE IS CREATED

-- CREATE TABLES

--Status
CREATE TABLE status(
ID INT NOT NULL PRIMARY KEY,
Status varchar(15)
)
insert into status
select 1,'Available'

insert into status
select 2,'Not Available'

insert into status
select 22,'Arrived'

insert into status
select 11,'NO SHOW'


-- Users info

CREATE TABLE Users(
	UserID int IDENTITY(1,1) PRIMARY KEY,
	Username VARCHAR (20),
	Firstname VARCHAR (20),
	Lastname VARCHAR(30),
	Email VARCHAR(100),
	Phone INT,
	Region VARCHAR(50),
	Birthday DATE,
	AdminLevel INT
)

CREATE TABLE UserLogin(
	UserID int FOREIGN KEY REFERENCES Users(UserID),
	Username VARCHAR (20),
	password NVARCHAR (20),
)

--- Venue info

CREATE TABLE Venues(
	VenueID int IDENTITY(1,1) PRIMARY KEY,
	Name varchar (50),
	Limit int,
	EmployeeQty int,
	Region varchar(50),
	Type varchar(50),
	CVR varchar(50)
)

CREATE TABLE VenueItems(
	VenueID int FOREIGN KEY REFERENCES Venues(VenueID),
	TableID int IDENTITY(1,1) PRIMARY KEY,
	TableNr int,
	Pax int,
	TableType varchar(50),
	Status int FOREIGN KEY REFERENCES status(ID)
)
CREATE TABLE VenueOwners(
	UserID int FOREIGN KEY REFERENCES Users(UserID),
	VenueID int FOREIGN KEY REFERENCES Venues(VenueID),
)


-- Bookings

CREATE TABLE Bookings(
	ID int IDENTITY(1,1) PRIMARY KEY,
	UserID int FOREIGN KEY REFERENCES Users(UserID),
	VenueID int FOREIGN KEY REFERENCES Venues(VenueID),
	Time datetime,
	Pax int,
	Note varchar(max),
	TableID int FOREIGN KEY REFERENCES VenueItems(TableID),
	status int FOREIGN KEY REFERENCES status(ID)
)

-- Regions
CREATE TABLE Regions(
	ID int IDENTITY(1,1),
	Regions varchar(50),
	Country varchar(10)
)


