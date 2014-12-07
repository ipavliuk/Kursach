use [RentApartments]
Go
CREATE TABLE PropertyListing__Amenities (FK_PropertyListing int NOT NULL, FK__Amenities int NOT NULL, PRIMARY KEY (FK_PropertyListing, FK__Amenities));
Go
CREATE TABLE _Roles (RoleId tinyint IDENTITY(1,1) NOT NULL, RoleName varchar(15) NOT NULL UNIQUE, RoleDescription varchar(40) NULL, CONSTRAINT RoleId PRIMARY KEY (RoleId));
Go
CREATE TABLE Reservations (ReservationId int IDENTITY(1,1) NOT NULL, FK_Account int NOT NULL, FK_PropertyListing int NOT NULL, ReservationStatus int NOT NULL, ReservationStart datetime NOT NULL, ReservationEnd datetime NOT NULL, ReservationNote nvarchar(255) NULL, FK__Currency int NOT NULL, PRIMARY KEY (ReservationId));
Go
CREATE TABLE Messages (MessageId int IDENTITY(1,1) NOT NULL, MessageType tinyint NOT NULL, MessageStatus tinyint NOT NULL, MessageBody nvarchar(255) NOT NULL, FK_Account int NOT NULL, PRIMARY KEY (MessageId));
Go
CREATE TABLE GuestReviews (ReviewId int IDENTITY(1,1) NOT NULL, FK_Account int NOT NULL, FK_PropertyListing int NOT NULL, Review nvarchar(255) NOT NULL, RatingScore int NOT NULL, PRIMARY KEY (ReviewId));
Go
CREATE TABLE _Amenities (id int IDENTITY(1,1) NOT NULL, Name nvarchar(255) NOT NULL, Description nvarchar(255) NULL, IsActive bit NOT NULL, CONSTRAINT Description PRIMARY KEY (id));
Go
CREATE TABLE _Currency (Id int IDENTITY(1,1) NOT NULL, Country nvarchar(255) NOT NULL, Currency nvarchar(255) NOT NULL, Code nvarchar(3) NOT NULL, Symbol nvarchar(255) NOT NULL, PRIMARY KEY (Id));
Go
CREATE TABLE PropertyListing (PropertyId int IDENTITY(1,1) NOT NULL, State tinyint NOT NULL, PricePerNight bigint NULL, PricePerMonth bigint NULL, PricePerWeek bigint NULL, Photos nvarchar(2000) NULL, GreatTitle nvarchar(40) NULL, GreatSummary nvarchar(255) NULL, BedRoom tinyint NOT NULL, Bathroom int NOT NULL, HomeType tinyint NOT NULL, RoomType tinyint NOT NULL, Accommodates tinyint NOT NULL, Address1 nvarchar(50) NULL, Address2 nvarchar(50) NULL, City nvarchar(20) NULL, State2 nvarchar(255) NULL, Zip nvarchar(10) NULL, FK__Country int NOT NULL, PRIMARY KEY (PropertyId));
Go
CREATE TABLE _Country (id int IDENTITY(1,1) NOT NULL, IsoCode varchar(2) NOT NULL, Name varchar(255) NOT NULL, PRIMARY KEY (id));
Go
CREATE TABLE Account (id int IDENTITY(1,1) NOT NULL, AccountId nvarchar(255) NOT NULL UNIQUE, PasswordHash nvarchar(255) NOT NULL, FirstName nvarchar(255) NOT NULL, LastName nvarchar(255) NOT NULL, Email nvarchar(255) NOT NULL, IsEmailConfirmed bit NOT NULL, FK__Country int NOT NULL, FK__Roles tinyint NOT NULL, City nvarchar(255) NULL, Address nvarchar(255) NULL, Mobile nvarchar(15) NULL, Gender tinyint NULL, PostalCode nvarchar(255) NULL, Language int NULL, IsValidated bit NOT NULL, ImageSourceId nvarchar(255) NULL, PRIMARY KEY (id));
Go
ALTER TABLE Reservations ADD CONSTRAINT FKReservatio820773 FOREIGN KEY (FK_Account) REFERENCES Account (id);
Go
ALTER TABLE Messages ADD CONSTRAINT FKMessages695479 FOREIGN KEY (FK_Account) REFERENCES Account (id);
Go
ALTER TABLE GuestReviews ADD CONSTRAINT FKGuestRevie904213 FOREIGN KEY (FK_Account) REFERENCES Account (id);
Go
ALTER TABLE PropertyListing ADD CONSTRAINT FKPropertyLi968374 FOREIGN KEY (FK__Country) REFERENCES _Country (id);
Go
ALTER TABLE Reservations ADD CONSTRAINT FKReservatio873284 FOREIGN KEY (FK__Currency) REFERENCES _Currency (Id);
Go
ALTER TABLE PropertyListing__Amenities ADD CONSTRAINT FKPropertyLi69776 FOREIGN KEY (FK_PropertyListing) REFERENCES PropertyListing (PropertyId);
Go
ALTER TABLE PropertyListing__Amenities ADD CONSTRAINT FKPropertyLi611631 FOREIGN KEY (FK__Amenities) REFERENCES _Amenities (id);
Go
ALTER TABLE GuestReviews ADD CONSTRAINT FKGuestRevie649365 FOREIGN KEY (FK_PropertyListing) REFERENCES PropertyListing (PropertyId);
Go
ALTER TABLE Account ADD CONSTRAINT FKAccount860859 FOREIGN KEY (FK__Roles) REFERENCES _Roles (RoleId);
Go
ALTER TABLE Reservations ADD CONSTRAINT FKReservatio405665 FOREIGN KEY (FK_PropertyListing) REFERENCES PropertyListing (PropertyId);
Go
ALTER TABLE Account ADD CONSTRAINT FKAccount816800 FOREIGN KEY (FK__Country) REFERENCES _Country (id);
GO

