use [RentApartments]
Go
ALTER TABLE PropertyListing DROP CONSTRAINT FKPropertyLi96721;
ALTER TABLE PropertyListing DROP CONSTRAINT FKPropertyLi101343;
ALTER TABLE Reservations DROP CONSTRAINT FKReservatio820773;
ALTER TABLE Messages DROP CONSTRAINT FKMessages695479;
ALTER TABLE GuestReviews DROP CONSTRAINT FKGuestRevie904213;
ALTER TABLE PropertyListing DROP CONSTRAINT FKPropertyLi968374;
ALTER TABLE Reservations DROP CONSTRAINT FKReservatio101343;
ALTER TABLE PropertyListing__Amenities DROP CONSTRAINT FKPropertyLi69776;
ALTER TABLE PropertyListing__Amenities DROP CONSTRAINT FKPropertyLi611631;
ALTER TABLE GuestReviews DROP CONSTRAINT FKGuestRevie649365;
ALTER TABLE Account DROP CONSTRAINT FKAccount860859;
ALTER TABLE Reservations DROP CONSTRAINT FKReservatio405665;
ALTER TABLE Account DROP CONSTRAINT FKAccount816800;
DROP TABLE PropertyListing__Amenities;
DROP TABLE _Roles;
DROP TABLE Reservations;
DROP TABLE Messages;
DROP TABLE GuestReviews;
DROP TABLE _Amenities;
DROP TABLE _Currency;
DROP TABLE PropertyListing;
DROP TABLE _Country;
DROP TABLE Account;
Go
 